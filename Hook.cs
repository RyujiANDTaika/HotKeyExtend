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
    class Hook
    {
        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);   //钩子子程的委托

        static int hKeyboardHook = 0;   //初始化键盘钩子子程的句柄
        static int hMouseHook = 0;      //初始化鼠标钩子子程的句柄

        public const int WH_KEYBOARD_LL = 13;   //键盘钩子类型
        public const int WH_MOUSE_LL = 14;      //鼠标钩子类型

        private static HookProc KeyboardHookProcedure;
        private static HookProc MouseHookProcedure;

        //挂载钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        //卸载钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        //将消息传递至下一个钩子子程
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

        //模拟按键按下
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        // 取得当前线程编号
        [DllImport("kernel32.dll")]
        static extern int GetCurrentThreadId();

        //使用WINDOWS API函数代替获取当前实例的函数,防止钩子失效
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        public void Start()
        {
            if (hKeyboardHook == 0)
            {
                KeyboardHookProcedure = new HookProc(KeyboardHookProc);    //委托实例化
                hKeyboardHook = SetWindowsHookEx(
                    WH_KEYBOARD_LL,                                         //键盘类型
                    KeyboardHookProcedure,                                  //钩子子程
                    Process.GetCurrentProcess().MainWindowHandle,           //当前程序的句柄
                    0);
            }

            if(hMouseHook == 0)
            {
                MouseHookProcedure = new HookProc(MouseHookProc);
                hMouseHook = SetWindowsHookEx(
                    WH_MOUSE_LL,
                    MouseHookProcedure,
                    Process.GetCurrentProcess().MainWindowHandle,
                    0);
            }
        }

        public void Stop()
        {
            if(hKeyboardHook != 0)
            {
                UnhookWindowsHookEx(hKeyboardHook);
            }

            if(hMouseHook != 0)
            {
                UnhookWindowsHookEx(hMouseHook);
            }
        }

        

        public delegate void keyboardServiceEventHandler(Int32 wParam, IntPtr lParam);
        public event keyboardServiceEventHandler keyboardService;

        public int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            
            keyboardService(wParam, lParam);

            return CallNextHookEx(hKeyboardHook,nCode,wParam,lParam);
        }

        

        public delegate void mouseServiceEventHandler(Int32 wParam, IntPtr lParam);
        public event mouseServiceEventHandler mouseService;

        public int MouseHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            
            mouseService(wParam, lParam);
            return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }
    }
}
