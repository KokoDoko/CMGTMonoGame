using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JibbyIsMyFriend
{
    class Washing : AbstractAction
    {
        private int _timeOfAction = 4000;

        public Washing(Jibby owner)
            : base(owner)
        {

        }

        public override void Execute()
        {
            //StateOwner.IsInAction = true;
            StartTimer(_timeOfAction);

            Debug.WriteLine("IsWashing");
            base.Execute();
        }

        protected override void OnActionEnd()
        {
            Debug.WriteLine("Done IsWashing");
            
            StateOwner.Hygiene += 10;
            
            StateOwner.IsInAction = false;
        }
    }
}
