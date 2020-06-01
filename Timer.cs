using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotkeyExtend
{
    class Timer
    {
        //定义Timer类变量
        private static int interval = 1000;//时间间隔触发事件，单位ms
        private System.Timers.Timer Mytimer = new System.Timers.Timer(interval);

        //用于表示时间，单位s
        private long TimeCount;
        //表示此时计时器的状态
        private bool status = false;

        public delegate void timerEndEventHandler();
        public timerEndEventHandler timerEnd;

        public void start()
        {
            TimeCount = 3;
            Mytimer.Start();
            Mytimer.Elapsed += new System.Timers.ElapsedEventHandler(Mytimer_tick);
            status = true;
        }

        //结束计时
        public void stop()
        {
            Mytimer.Stop();
            status = false;
        }

        //每经过时间间隔触发一次
        private void Mytimer_tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            TimeCount--;//每经过时间间隔减1s
            if (TimeCount == 0)
            {
                stop();//计时结束
                timerEnd();//直接调用timerEnd()
                start();//重新开始计时
            }

        }
        private void ShowTime(long TimeCount)
        {
            TimeSpan temp = new TimeSpan(0, 0, (int)(TimeCount));
            Console.WriteLine(string.Format("{0:00}:{1:00}:{2:00}", temp.Hours, temp.Minutes, temp.Seconds));
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
