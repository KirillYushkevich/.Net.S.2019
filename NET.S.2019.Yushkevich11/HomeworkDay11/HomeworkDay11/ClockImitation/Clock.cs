using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace HomeworkDay11.ClockImitation
{
    public class Clock
    {
        private Timer timer = new Timer();

        public Clock(long ticks, EventHandler<TimeOutEventArgs> callBackMethod)
        {
            timer.Interval = ticks * 1000;
            timer.Elapsed += TimerTimeOut;
            TimeOut += callBackMethod;
            timer.Start();
        }

        private delegate void MessegeInfo(string messege);

        public event EventHandler<TimeOutEventArgs> TimeOut;

        protected virtual void TimerTimeOut(object sender, ElapsedEventArgs e)
        {
            TimeOut?.Invoke(this, new TimeOutEventArgs());
        }

        public class TimeOutEventArgs : EventArgs
        {
            public DateTime FinishTime = DateTime.Now;
        }
    }
}
