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
using System.Text.RegularExpressions;

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

            TextSearchModule textSearchModule = new TextSearchModule();
            for (int i = 0; i < searchTextStatus.Count(); i++)
            {
                if (searchTextStatus[i])
                {
                    textSearchModule.addKeyList(searchText[i * 4 + 1], searchText[i * 4 + 2], searchText[i * 4 + 3]);
                }
            }
            msgManager += textSearchModule.judgeMsg;

            List<string> replaceText = settingsAdapter.settings.replaceText;
            List<bool> replaceTextStatus = settingsAdapter.settings.replaceTextStatus;

            for (int i = 0; i < replaceTextStatus.Count(); i++)
            {
                if (replaceTextStatus[i])
                {
                    TextReplaceModule textReplaceModule = new TextReplaceModule(replaceText[i * 2], replaceText[i * 2 + 1]);
                    msgManager += textReplaceModule.judgeMsg;
                }
            }

        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern short VkKeyScanEx(char ch, IntPtr dwhkl);

        public class TextReplaceModule {
            public string inputString;
            public string outputString;
            public TextReplaceModule(string inputString,string outputString)
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


        public class TextSearchModule
        {
            

            public TextSearchModule()
            {
                
                generateKeyList();
            }

            private bool ctrlKeyStatus;     //162
            private bool shiftKeyStatus;    //160
            private bool winKeyStatus;      //91
            private bool altKeyStatus;      //164
            private List<short> keyList;
            private int keyNum = 0;

            public void judgeMsg(Int32 wParam, KBDLLHOOKSTRUCT msg)
            {
                //win
                if (msg.vkCode == 91 && wParam == WM_KEYDOWN)
                {
                    winKeyStatus = true;
                    return;
                }
                if (msg.vkCode == 91 && wParam == WM_KEYUP)
                {
                    winKeyStatus = false;
                    return;
                }
                //shift
                if (msg.vkCode == 160 && wParam == WM_KEYDOWN)
                {
                    shiftKeyStatus = true;
                    return;
                }
                if (msg.vkCode == 160 && wParam == WM_KEYUP)
                {
                    shiftKeyStatus = false;
                    return;
                }
                //alt
                if (msg.vkCode == 164 && wParam == WM_SYSKEYDOWN)
                {
                    altKeyStatus = true;
                    return;
                }
                if (msg.vkCode == 164 && wParam == WM_KEYUP)
                {
                    altKeyStatus = false;
                    return;
                }
                //ctrl
                if (msg.vkCode == 162 && wParam == WM_KEYDOWN)
                {
                    ctrlKeyStatus = true;
                    return;
                }
                if (msg.vkCode == 162 && wParam == WM_KEYUP)
                {
                    ctrlKeyStatus = false;
                    return;
                }

                if (keyNum == keyList.Count() && wParam == WM_KEYDOWN)
                {
                    keyNum = 0;
                    if(msg.vkCode >= 48 && msg.vkCode <= 57)
                    {
                        if(group[msg.vkCode - 48] != null)
                        {
                            foreach (int i in group[msg.vkCode - 48])
                            {
                                openUrl(urlList[i]);
                            }
                        }
                    }

                    foreach(hotKey h in hotKeyList)
                    {
                        if(msg.vkCode == h.keyCode &&
                            altKeyStatus == h.altKeyStatus &&
                            winKeyStatus == h.winKeyStatus &&
                            ctrlKeyStatus == h.ctrlKeyStatus &&
                            shiftKeyStatus == h.shiftKeyStatus)
                        {
                            openUrl(urlList[hotKeyList.IndexOf(h)]);
                        }
                    }
                }

                if (keyNum == keyList.Count() && wParam == WM_SYSKEYDOWN)
                {
                    foreach (hotKey h in hotKeyList)
                    {
                        if (msg.vkCode == h.keyCode &&
                            altKeyStatus == h.altKeyStatus &&
                            winKeyStatus == h.winKeyStatus &&
                            ctrlKeyStatus == h.ctrlKeyStatus &&
                            shiftKeyStatus == h.shiftKeyStatus)
                        {
                            openUrl(urlList[hotKeyList.IndexOf(h)]);
                        }
                    }
                }

                if (keyNum < keyList.Count() && wParam == WM_KEYDOWN)
                {
                    if (ctrlKeyStatus)
                    {
                        //用低8位进行判断
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
                        keyNum = 0;
                    }
                }
            }

            public void generateKeyList()
            {
                keyList = new List<short>();
                keyList.Add(VkKeyScanEx('c', (IntPtr)0));
                keyList.Add(VkKeyScanEx('c', (IntPtr)0));
            }

            private List<int>[] group = new List<int>[10];
            private List<hotKey> hotKeyList = new List<hotKey>();
            private List<string> urlList = new List<string>();

            struct hotKey {
                public int keyCode;
                public bool shiftKeyStatus;
                public bool winKeyStatus;
                public bool ctrlKeyStatus;
                public bool altKeyStatus;
                public hotKey(string text)
                {
                    string[] textString = text.Split('_');
                    keyCode = getKeyCode(textString.Last());
                    if (textString.Contains("Ctrl"))
                        ctrlKeyStatus = true;
                    else
                        ctrlKeyStatus = false;

                    if (textString.Contains("Shift"))
                        shiftKeyStatus = true;
                    else
                        shiftKeyStatus = false;

                    if (textString.Contains("Win"))
                        winKeyStatus = true;
                    else
                        winKeyStatus = false;

                    if (textString.Contains("Alt"))
                        altKeyStatus = true;
                    else
                        altKeyStatus = false;
                }
            }

            public void addKeyList(string hotkey,string groupkey,string url)
            {
                hotKeyList.Add(new hotKey(hotkey));
                urlList.Add(url);
                if (groupkey.Length != 0)
                {
                    int index = (int)groupkey[1] - 48;
                    if (group[index] == null)
                        group[index] = new List<int>();
                    group[index].Add(urlList.IndexOf(url));
                }
            }

            public void openUrl(string url)
            {
                string text = Clipboard.GetText();
                Process.Start(url.Replace("%s", text));
            }

            public static int getKeyCode(string str)
            {
                foreach(int i in Keys.GetValues(typeof(Keys)))
                {
                    string name = Keys.GetName(typeof(Keys), i);
                    if (name == str)
                        return i;
                }
                return 0;
            }
        }
    }
}
