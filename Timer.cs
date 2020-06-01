using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotkeyExtend
{
    class Timer
    {
        public delegate void timerEndEventHandler();
        public timerEndEventHandler timerEnd;

        public void start()
        {

        }

        public bool hasEvent(timerEndEventHandler timerEndEvent)
        {
            Delegate[] delegates = timerEnd.GetInvocationList();
            return Array.IndexOf(delegates, timerEndEvent) >= 0;
        }

        public void restart(timerEndEventHandler timerEndEvent)
        {
            timerEnd = null;    //清空事件列表
            timerEnd += timerEndEvent;
            start();
        }
    }
}
