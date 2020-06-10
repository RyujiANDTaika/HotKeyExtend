using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using HotkeyExtend.Properties;

namespace HotkeyExtend
{
    class KeyboardService
    {
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;

        //KBDLLHOOKSTRUCT 键盘钩子获取到的消息体
        [StructLayout(LayoutKind.Sequential)]
        public class KBDLLHOOKSTRUCT
        {
            public int vkCode;          //虚拟键码
            public int scanCode;
            public int flags;
            public int time;            //时间戳
            public int dwExtraInfo;
        }

        private delegate void msgManagerEventHandler(Int32 wParam, KBDLLHOOKSTRUCT msg);
        private event msgManagerEventHandler msgManager;

        public void keyboardMsgReceiver(Int32 wParam, IntPtr lParam)
        {
            KBDLLHOOKSTRUCT msg = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
            msgManager?.Invoke(wParam, msg);
        }

        public KeyboardService()
        {
            msgManager = null;
        }

        private static SettingsAdapter settingsAdapter = new SettingsAdapter();
        private static Operation operation = new Operation();

        public void updateService()
        {
            //先清空事件
            msgManager = null;

            List<string> searchText = settingsAdapter.settings.searchText;
            List<bool> searchTextStatus = settingsAdapter.settings.searchTextStatus;

            List<string> replaceText = settingsAdapter.settings.replaceText;
            List<bool> replaceTextStatus = settingsAdapter.settings.replaceTextStatus;

            for (int i = 0; i < replaceTextStatus.Count(); i++)
            {
                if (replaceTextStatus[i])
                {
                    TestReplaceModule testReplaceModule = new TestReplaceModule(replaceText[i * 2], replaceText[i * 2 + 1]);
                    msgManager += testReplaceModule.judgeMsg;
                }
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern short VkKeyScanEx(char ch, IntPtr dwhkl);

        public class TestReplaceModule {
            public string inputString;
            public string outputString;
            public TestReplaceModule(string inputString,string outputString)
            {
                this.inputString = inputString;
                this.outputString = outputString;

                generateKeyList();
            }

            private int keyNum = 0;
            private bool shiftKeyStatus;
            private List<short> keyList;

            public void judgeMsg(Int32 wParam, KBDLLHOOKSTRUCT msg)
            {
                if (msg.vkCode == 160 && wParam == WM_KEYDOWN)
                {
                    shiftKeyStatus = true;
                    return;
                }
                if(msg.vkCode == 160 && wParam == WM_KEYUP)
                {
                    shiftKeyStatus = false;
                    return;
                }

                if (keyNum < keyList.Count() && wParam == WM_KEYDOWN)
                {
                    //当按键的高位为0时
                    if (keyList[keyNum] < 256)
                    {
                        if (keyList[keyNum] == msg.vkCode)
                        {
                            keyNum++;
                        }
                        else
                        {
                            keyNum = 0;
                        }
                    }
                    else
                    {
                        //当按键的高位不为0则需要按下shift
                        if (shiftKeyStatus)
                        {
                            //用低8位进行判断
                            if (((byte)keyList[keyNum] & 0xff) == msg.vkCode)
                            {
                                keyNum++;
                            }
                            else
                            {
                                keyNum = 0;
                            }
                        }
                        else
                        {
                            keyNum = 0;
                        }
                    }
                }

                //当最后一个按键弹起时触发替换操作
                if(keyNum == keyList.Count() && wParam == WM_KEYUP)
                {
                    keyNum = 0;
                    Console.WriteLine("success");
                    SendKeys.SendWait("{BACKSPACE " + inputString.Length + "}");
                    SendKeys.Send(this.outputString);
                    return;
                }

            }

            public void generateKeyList()
            {
                keyList = new List<short>();
                foreach(char c in this.inputString)
                {
                    short keyCode = VkKeyScanEx(c, (IntPtr)0);
                    keyList.Add(keyCode);
                }
            }
        } 

    }
}
