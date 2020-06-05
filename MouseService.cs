using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;

namespace HotkeyExtend
{
    class MouseService
    {
        private static Operation operation = new Operation();

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
            msgManager?.Invoke(wParam, msg);
            timerInterrupt(wParam, msg);
        }

        public MouseService()
        {
            initialBlockEvent();
        }

        public void initialBlockEvent()
        {
            topLeftBlock = new BlockEvent();
            topMiddleBlock = new BlockEvent();
            topRightBlock = new BlockEvent();
            middleLeftBlock = new BlockEvent();
            middleRightBlock = new BlockEvent();
            bottomLeftBlock = new BlockEvent();
            bottomMiddleBlock = new BlockEvent();
            bottomRightBlock = new BlockEvent();

            blockList = new List<BlockEvent>();
            blockList.Add(topLeftBlock);
            blockList.Add(topMiddleBlock);
            blockList.Add(topRightBlock);
            blockList.Add(middleLeftBlock);
            blockList.Add(middleRightBlock);
            blockList.Add(bottomLeftBlock);
            blockList.Add(bottomMiddleBlock);
            blockList.Add(bottomRightBlock);

            blockFuncList = new List<msgManagerEventHandler>();
            blockFuncList.Add(topLeftHandle);
            blockFuncList.Add(topMiddleHandle);
            blockFuncList.Add(topRightHandle);
            blockFuncList.Add(middleLeftHandle);
            blockFuncList.Add(middleRightHandle);
            blockFuncList.Add(bottomLeftHandle);
            blockFuncList.Add(bottomMiddleHandle);
            blockFuncList.Add(bottomRightHandle);

            msgManager = null;
        }


        public delegate void mouseEventHandler();

        public class BlockEvent
        {
            public event mouseEventHandler wheelForward;
            public event mouseEventHandler wheelBackward;
            public event mouseEventHandler wheelDown;
            public event mouseEventHandler stay;
            public void wheelForwardInvoke() { wheelForward?.Invoke(); }
            public void wheelBackwardInvoke() { wheelBackward?.Invoke(); }
            public void wheelDownInvoke() { wheelDown?.Invoke(); }
            public void stayInvoke() { stay?.Invoke(); }
        }

        private BlockEvent topLeftBlock;
        private BlockEvent topMiddleBlock;
        private BlockEvent topRightBlock;
        private BlockEvent middleLeftBlock;
        private BlockEvent middleRightBlock;
        private BlockEvent bottomLeftBlock;
        private BlockEvent bottomMiddleBlock;
        private BlockEvent bottomRightBlock;

        private List<BlockEvent> blockList;

        private List<msgManagerEventHandler> blockFuncList;


        private static SettingsAdapter settingsAdapter = new SettingsAdapter();

        public void updateService()
        {
            initialBlockEvent();
            int[] statusArray = settingsAdapter.settings.screenBlockStatus;
            foreach(BlockEvent block in blockList)
            {
                int index = blockList.IndexOf(block);
                if(statusArray[index*4] == 1)
                {
                    addWheelEvent(block, statusArray[index * 4 + 1]);
                    addWheelDownEvent(block, statusArray[index * 4 + 2]);
                    addStayEvent(block, statusArray[index * 4 + 3]);
                }
            }
            foreach(msgManagerEventHandler blockHandle in blockFuncList)
            {
                int index = blockFuncList.IndexOf(blockHandle);
                if (statusArray[index * 4] == 1)
                    msgManager += blockHandle;
            }
        }

        private void addWheelEvent(BlockEvent block, int wheel)
        {
            switch (wheel)
            {
                case 0: 
                    break;
                case 1: 
                    block.wheelForward += operation.volumeIncrease;
                    block.wheelBackward += operation.volumeDecrease;
                    break;
                case 2:
                    block.wheelForward += operation.mediaPrevious;
                    block.wheelBackward += operation.mediaNext;
                    break;
                case 3:
                    block.wheelForward += operation.pageSwitchRight;
                    block.wheelBackward += operation.pageSwitchLeft;
                    break;
                case 4:
                    block.wheelForward += operation.applicationChange;
                    block.wheelBackward += operation.applicationChange;
                    break;
                case 5:
                    block.wheelForward += operation.virtualDesktop;
                    block.wheelBackward += operation.virtualDesktop;
                    break;
                case 6:
                    block.wheelForward += operation.pageUp;
                    block.wheelBackward += operation.pageDown;
                    break;
                case 7:
                    block.wheelForward += operation.pageHead;
                    block.wheelBackward += operation.pageEnd;
                    break;
            }
        }

        private void addWheelDownEvent(BlockEvent block, int wheelDown)
        {
            switch (wheelDown)
            {
                case 0:
                    break;
                case 1:
                    block.wheelDown += operation.volumeIncrease;
                    break;
                case 2:
                    block.wheelDown += operation.volumeDecrease;
                    break;
                case 3:
                    block.wheelDown += operation.volumeMute;
                    break;
                case 4:
                    block.wheelDown += operation.mediaPrevious;
                    break;
                case 5:
                    block.wheelDown += operation.mediaNext;
                    break;
                case 6:
                    block.wheelDown += operation.mediaPlayPause;
                    break;
                case 7:
                    block.wheelDown += operation.transparencyIncrease;
                    break;
                case 8:
                    block.wheelDown += operation.transparencyDecrease;
                    break;
                case 9:
                    block.wheelDown += operation.applicationChange;
                    break;
                case 10:
                    block.wheelDown += operation.shutDownMonitor;
                    break;
                case 11:
                    block.wheelDown += operation.systemHibernates;
                    break;
                case 12:
                    block.wheelDown += operation.systemsuspended;
                    break;
            }
        }

        private void addStayEvent(BlockEvent block, int stay)
        {
            switch (stay)
            {
                case 0:
                    break;
                case 1:
                    block.stay += operation.volumeIncrease;
                    break;
                case 2:
                    block.stay += operation.volumeDecrease;
                    break;
                case 3:
                    block.stay += operation.volumeMute;
                    break;
                case 4:
                    block.stay += operation.mediaPrevious;
                    break;
                case 5:
                    block.stay += operation.mediaNext;
                    break;
                case 6:
                    block.stay += operation.mediaPlayPause;
                    break;
                case 7:
                    block.stay += operation.transparencyIncrease;
                    break;
                case 8:
                    block.stay += operation.transparencyDecrease;
                    break;
                case 9:
                    block.stay += operation.applicationChange;
                    break;
                case 10:
                    block.stay += operation.shutDownMonitor;
                    break;
                case 11:
                    block.stay += operation.systemHibernates;
                    break;
                case 12:
                    block.stay += operation.systemsuspended;
                    break;
            }
        }

        private int height = Screen.PrimaryScreen.Bounds.Height;
        private int width = Screen.PrimaryScreen.Bounds.Width;

        private static Timer timer = new Timer();

        public void timerInterrupt(Int32 wParam, MSLLHOOKSTRUCT msg)
        {
            if(msg.pt.x >= 5 && msg.pt.x <= width - 5 && msg.pt.y >= 5 && msg.pt.y <= height - 5)
            {
                timer.interrupt();
            }
        }

        public void topLeftHandle(Int32 wParam, MSLLHOOKSTRUCT msg)
        {
            if (msg.pt.x >= 0 && msg.pt.x <= 5 && msg.pt.y >= 0 && msg.pt.y <= 5)
            {
                //按下滚轮
                if (wParam == WM_MOUSEWHEELDOWN)
                {
                    topLeftBlock.wheelDownInvoke();
                }
                //滚轮滚动
                if (wParam == WM_MOUSEWHEEL)
                {
                    if (msg.mouseData > 0)
                        topLeftBlock.wheelForwardInvoke();
                    else
                        topLeftBlock.wheelBackwardInvoke();
                }
                //不动
                timer.addEvent(topLeftBlock.stayInvoke);
            }
        }

        public void topMiddleHandle(Int32 wParam, MSLLHOOKSTRUCT msg)
        {
            if (msg.pt.x >= 5 && msg.pt.x <= width -5 && msg.pt.y == 0)
            {
                if (wParam == WM_MOUSEWHEELDOWN)
                {
                    topMiddleBlock.wheelDownInvoke();
                }
                if (wParam == WM_MOUSEWHEEL)
                {
                    if (msg.mouseData > 0)
                        topMiddleBlock.wheelForwardInvoke();
                    else
                        topMiddleBlock.wheelBackwardInvoke();
                }
                timer.addEvent(topMiddleBlock.stayInvoke);
            }
        }

        public void topRightHandle(Int32 wParam, MSLLHOOKSTRUCT msg)
        {
            if (msg.pt.x >= width - 5 && msg.pt.x <= width && msg.pt.y >= 0 && msg.pt.y <= 5)
            {
                if (wParam == WM_MOUSEWHEELDOWN)
                {
                    topRightBlock.wheelDownInvoke();
                }
                if (wParam == WM_MOUSEWHEEL)
                {
                    if (msg.mouseData > 0)
                        topRightBlock.wheelForwardInvoke();
                    else
                        topRightBlock.wheelBackwardInvoke();
                }
                timer.addEvent(topRightBlock.stayInvoke);
            }
        }

        public void middleLeftHandle(Int32 wParam, MSLLHOOKSTRUCT msg)
        {
            if (msg.pt.x == 0 && msg.pt.y >= 5 && msg.pt.y <= height - 5)
            {
                if (wParam == WM_MOUSEWHEELDOWN)
                {
                    middleLeftBlock.wheelDownInvoke();
                }
                if (wParam == WM_MOUSEWHEEL)
                {
                    if (msg.mouseData > 0)
                        middleLeftBlock.wheelForwardInvoke();
                    else
                        middleLeftBlock.wheelBackwardInvoke();
                }
                timer.addEvent(middleLeftBlock.stayInvoke);
            }
        }

        public void middleRightHandle(Int32 wParam, MSLLHOOKSTRUCT msg)
        {
            if (msg.pt.x <= width && msg.pt.x >= width - 5 && msg.pt.y >= 5 && msg.pt.y <= height - 5)
            {
                if (wParam == WM_MOUSEWHEELDOWN)
                {
                    middleRightBlock.wheelDownInvoke();
                }
                if (wParam == WM_MOUSEWHEEL)
                {
                    if (msg.mouseData > 0)
                        middleRightBlock.wheelForwardInvoke();
                    else
                        middleRightBlock.wheelBackwardInvoke();
                }
                timer.addEvent(middleRightBlock.stayInvoke);
            }
        }

        public void bottomLeftHandle(Int32 wParam, MSLLHOOKSTRUCT msg)
        {
            if (msg.pt.x >= 0 && msg.pt.x <= 5 && msg.pt.y >= height - 5 && msg.pt.y <= height)
            {
                if (wParam == WM_MOUSEWHEELDOWN)
                {
                    bottomLeftBlock.wheelDownInvoke();
                }
                if (wParam == WM_MOUSEWHEEL)
                {
                    if (msg.mouseData > 0)
                        bottomLeftBlock.wheelForwardInvoke();
                    else
                        bottomLeftBlock.wheelBackwardInvoke();
                }
                timer.addEvent(bottomLeftBlock.stayInvoke);
            }
        }

        public void bottomMiddleHandle(Int32 wParam, MSLLHOOKSTRUCT msg)
        {
            if (msg.pt.x >= 5 && msg.pt.x <= width - 5 && msg.pt.y <= height && msg.pt.y >= height - 5)
            {
                if (wParam == WM_MOUSEWHEELDOWN)
                {
                    bottomMiddleBlock.wheelDownInvoke();
                }
                if (wParam == WM_MOUSEWHEEL)
                {
                    if (msg.mouseData > 0)
                        bottomMiddleBlock.wheelForwardInvoke();
                    else
                        bottomMiddleBlock.wheelBackwardInvoke();
                }
                timer.addEvent(bottomMiddleBlock.stayInvoke);
            }
        }

        public void bottomRightHandle(Int32 wParam, MSLLHOOKSTRUCT msg)
        {
            if (msg.pt.x >= width - 5 && msg.pt.x <= width && msg.pt.y >= height - 5 && msg.pt.y <= height)
            {
                if (wParam == WM_MOUSEWHEELDOWN)
                {
                    bottomRightBlock.wheelDownInvoke();
                }
                if (wParam == WM_MOUSEWHEEL)
                {
                    if (msg.mouseData > 0)
                        bottomRightBlock.wheelForwardInvoke();
                    else
                        bottomRightBlock.wheelBackwardInvoke();
                }
                timer.addEvent(bottomRightBlock.stayInvoke);
            }
        }
    }
}
