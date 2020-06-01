using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.CodeDom;

namespace HotkeyExtend
{
    class Operation
    {
        //模拟按键按下
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, Int32 wParam, Int32 lParam);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();


        private IntPtr handle;
        private IntPtr HWND_BROADCAST = (IntPtr)0xffff;

        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        public void volumeIncrease()
        {
            handle = Process.GetCurrentProcess().MainWindowHandle;
            IntPtr res = SendMessageW(handle, WM_APPCOMMAND, handle, (IntPtr)APPCOMMAND_VOLUME_UP);
        }

        public void volumeDecrease()
        {
            handle = Process.GetCurrentProcess().MainWindowHandle;
            IntPtr res = SendMessageW(handle, WM_APPCOMMAND, handle, (IntPtr)APPCOMMAND_VOLUME_DOWN);
        }

        public void volumeMute()
        {
            handle = Process.GetCurrentProcess().MainWindowHandle;
            IntPtr res = SendMessageW(handle, WM_APPCOMMAND, handle, (IntPtr)APPCOMMAND_VOLUME_MUTE);
        }

        private const int APPCOMMAND_MEDIA_NEXTTRACK = 0xB0000;
        private const int APPCOMMAND_MEDIA_PREVIOUSTRACK = 0xC0000;
        private const int APPCOMMAND_MEDIA_PLAY_PAUSE = 0xD0000;

        public void mediaNext()
        {
            keybd_event(176, 0, 0, 0);
            keybd_event(176, 0, 2, 0);
        }

        public void mediaPrevious()
        {
            keybd_event(177, 0, 0, 0);
            keybd_event(177, 0, 2, 0);
        }

        public void mediaPlayPause()
        {
            keybd_event(179, 0, 0, 0);
            keybd_event(179, 0, 2, 0);
        }

        public void pageSwitchLeft()
        {
            keybd_event(17, 0, 0, 0);
            keybd_event(16, 0, 0, 0);
            keybd_event(9, 0, 0, 0);
            keybd_event(9, 0, 2, 0);
            keybd_event(16, 0, 2, 0);
            keybd_event(17, 0, 2, 0);
        }

        public void pageSwitchRight()
        {
            keybd_event(17, 0, 0, 0);
            keybd_event(9, 0, 0, 0);
            keybd_event(9, 0, 2, 0);
            keybd_event(17, 0, 2, 0);
        }

        public void applicationChange()
        {
            keybd_event(18, 0, 0, 0);
            keybd_event(9, 0, 0, 0);
            keybd_event(9, 0, 2, 0);
            keybd_event(18, 0, 2, 0);
        }

        public void virtualDesktop()
        {
            keybd_event(91, 0, 0, 0);
            keybd_event(9, 0, 0, 0);
            keybd_event(9, 0, 2, 0);
            keybd_event(91, 0, 2, 0);
        }

        public void pageUp()
        {
            keybd_event(33, 0, 0, 0);
            keybd_event(33, 0, 2, 0);
        }

        public void pageDown()
        {
            keybd_event(34, 0, 0, 0);
            keybd_event(34, 0, 2, 0);
        }

        public void pageHead()
        {
            keybd_event(36, 0, 0, 0);
            keybd_event(36, 0, 2, 0);
        }

        public void pageEnd()
        {
            keybd_event(35, 0, 0, 0);
            keybd_event(35, 0, 2, 0);
        }

        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);

        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        private static extern int SetLayeredWindowAttributes(IntPtr hwnd, int crKey, int bAlpha, int dwFlags);

        [DllImport("user32", EntryPoint = "GetLayeredWindowAttributes")]
        unsafe private static extern bool GetLayeredWindowAttributes(IntPtr hwnd, int* pcrKey, int* pbAlpha, int* pdwFlags);

        private const int GWL_EXSTYLE = (-20);
        private const uint WS_EX_LAYERED = 0x80000;
        private const int LWA_ALPHA = 2;

        unsafe public void transparencyIncrease()
        {
            IntPtr hwd = GetForegroundWindow();
            if (hwd != null)
            {
                int opacity;
                int lwa_alpha = 2;
                bool res = GetLayeredWindowAttributes(hwd, null, &opacity, &lwa_alpha);
                if (!res)
                {
                    SetWindowLong(hwd, GWL_EXSTYLE, WS_EX_LAYERED);
                    SetLayeredWindowAttributes(hwd, 0, 255, LWA_ALPHA);
                }
                else
                {
                    if(opacity + 15 <= 255)
                    {
                        SetLayeredWindowAttributes(hwd, 0, opacity + 15, LWA_ALPHA);
                    }
                }
                
            }
        }

        unsafe public void transparencyDecrease()
        {
            IntPtr hwd = GetForegroundWindow();
            if (hwd != null)
            {
                int opacity;
                int lwa_alpha = 2;
                bool res = GetLayeredWindowAttributes(hwd, null, &opacity, &lwa_alpha);
                if (!res)
                {
                    SetWindowLong(hwd, GWL_EXSTYLE, WS_EX_LAYERED);
                    SetLayeredWindowAttributes(hwd, 0, 255 - 15, LWA_ALPHA);
                }
                else
                {
                    if (opacity - 15 >= 0)
                    {
                        SetLayeredWindowAttributes(hwd, 0, opacity - 15, LWA_ALPHA);
                    }
                }

            }
        }

        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MONITORPOWER = 0xF170;
        
        public void shutDownMonitor()
        {
            SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, 2);
        }


        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        public void systemHibernates()
        {
            SetSuspendState(true, true, true);
        }

        public void systemsuspended()
        {
            SetSuspendState(false, true, true);
        }
    }
}
