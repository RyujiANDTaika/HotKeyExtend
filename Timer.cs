using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotkeyExtend
{
    class Timer
    {
        public Timer()
        {
            Mytimer.Elapsed += timeout;
            Mytimer.AutoReset = false;
        }

        //定义Timer类变量
        private static int interval = 3000;     //时间间隔触发事件，单位ms
        private static System.Timers.Timer Mytimer = new System.Timers.Timer(interval);

        public delegate void timerEndEventHandler();
        public timerEndEventHandler timerEnd;

        //每经过时间间隔触发一次
        private void timeout(object sender, System.Timers.ElapsedEventArgs e)
        {
            timerEnd();             //直接调用timerEnd()
            Mytimer.Start();
        }

        public bool hasEvent(timerEndEventHandler timerEndEvent)
        {
            Delegate[] delegates = timerEnd.GetInvocationList();
            return Array.IndexOf(delegates, timerEndEvent) >= 0;
        }

        public void addEvent(timerEndEventHandler timerEndEvent)
        {
            if(timerEnd == null)
            {
                timerEnd += timerEndEvent;
                Mytimer.Start();
            }
            else
            {
                Mytimer.Stop();
                if (!hasEvent(timerEndEvent))
                {
                    timerEnd = null;
                    timerEnd += timerEndEvent;
                }
                Mytimer.Start();
            }
        }

        public void interrupt()
        {
            timerEnd = null;
            Mytimer.Stop();
        }
    }
}
