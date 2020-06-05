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
                    TestClass testClass = new TestClass(replaceText[i * 2], replaceText[i * 2 + 1]);
                    msgManager += testClass.testFunc;
                }
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern short VkKeyScanEx(char ch, IntPtr dwhkl);

        public class TestClass {
            public string inputString;
            public string outputString;
            public TestClass(string inputString,string outputString)
            {
                this.inputString = inputString;
                this.outputString = outputString;
            }

            public struct KeyMsg
            {
                public int KeyStatus;
                public int KeyCode;
                public KeyMsg(int KeyStatus,int KeyCode)
                {
                    this.KeyStatus = KeyStatus;
                    this.KeyCode = KeyCode;
                }
            }

            private int keyNum = 0;
            private List<KeyMsg> keyList;

            public void testFunc(Int32 wParam, KBDLLHOOKSTRUCT msg)
            {
                generateKeyList();
                if(keyNum < keyList.Count())
                {
                    if(keyList[keyNum].KeyStatus == wParam && keyList[keyNum].KeyCode == msg.vkCode)
                    {
                        keyNum++;
                    }
                    else
                    {
                        //如果匹配中断则置零
                        keyNum = 0;
                    }
                }
                else
                {
                    //匹配成功后执行的操作

                }
                
                Console.WriteLine(VkKeyScanEx(this.inputString[0],(IntPtr)0) == msg.vkCode);

            }

            public void generateKeyList()
            {
                keyList = new List<KeyMsg>();
                foreach(char c in this.inputString)
                {
                    keyList.Add(new KeyMsg(WM_KEYDOWN, VkKeyScanEx(c, (IntPtr)0)));
                    keyList.Add(new KeyMsg(WM_KEYUP, VkKeyScanEx(c, (IntPtr)0)));
                }
            }
        } 

    }
}
