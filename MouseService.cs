using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace HotkeyExtend
{
    class MouseService
    {
        private Operation operation = new Operation();

        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_MOUSEWHEEL = 0x020A;   //滚轮旋转
        private const int WM_MOUSEWHEELDOWN = 0x0207;
        private const int WM_MOUSEWHEELUP = 0x0208;
        private const int WM_MOUSEHWHEEL = 0x020E;  //水平滚轮旋转？？？
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_RBUTTONUP = 0x0205;

        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
        };

        [StructLayout(LayoutKind.Sequential)]
        public class MSLLHOOKSTRUCT
        {
            public POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        private delegate void msgManagerEventHandler(Int32 wParam, MSLLHOOKSTRUCT msg);
        private msgManagerEventHandler msgManager;

        public void mouseMsgReceiver(Int32 wParam, IntPtr lParam)
        {
            MSLLHOOKSTRUCT msg = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
            msgManager(wParam, msg);
        }

        public void topLeftHandle(Int32 wParam, MSLLHOOKSTRUCT msg)
        {
            if(msg.pt.x >= 0 && msg.pt.x <= 5 && msg.pt.y >= 0 && msg.pt.y <= 5)
            {
                Console.WriteLine(wParam);
                if(wParam == WM_MOUSEWHEELDOWN)
                {
                    Console.WriteLine("yes");
                    topLeft_wheelDown();
                }
            }
        }

        public delegate void topLeft_wheelDownEventHandler();
        public event topLeft_wheelDownEventHandler topLeft_wheelDown;

        private static SettingsAdapter settingsAdapter = new SettingsAdapter();
        public void updateService()
        {
            int[] statusArray = settingsAdapter.settings.screenBlockStatus;
            if(statusArray[0] == 1)
                msgManager += topLeftHandle;
            if (statusArray[2] == 5)
                topLeft_wheelDown += operation.volumeIncrease;
        }
    }
}
