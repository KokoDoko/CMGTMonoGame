using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;

namespace JibbyIsMyFriend
{
    public abstract class AbstractAction
    {
        protected Timer Timer    { get; set; }

        public Jibby StateOwner  { get; set; }
        
        public AbstractAction(Jibby owner)
        {
            StateOwner      = owner;

            Timer           = new Timer();
            Timer.Elapsed  += new ElapsedEventHandler(OnTimerFinished);
            // Timer zal maar 1 keer een event moeten triggeren en daarna stoppen. Handmatig stoppen is dus niet nodig
            Timer.AutoReset = false;
        }

        protected void StartTimer(double interval)
        {
            Timer.Interval = interval;
            Timer.Start();        
        }

        private void OnTimerFinished(object sender, ElapsedEventArgs e)
        {
            OnActionEnd();
        }

        public virtual void Execute()
        {
            StateOwner.IsInAction = true;
            
        }

        protected abstract void OnActionEnd();
    }
}
