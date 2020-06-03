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

        public void updateService()
        {

        }
    }
}
