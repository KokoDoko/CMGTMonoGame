using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JibbyIsMyFriend
{
    class Eating : AbstractAction
    {
        private int _timeOfAction = 3000;

        public Eating(Jibby owner)
            : base(owner)
        {

        }

        public override void Execute()
        {
            //StateOwner.IsInAction = true;
            StartTimer(_timeOfAction);

            Debug.WriteLine("IsEating");
            // Toon de eetanimatie
            base.Execute();
        }

        protected override void OnActionEnd()
        {
            Debug.WriteLine("Done Eating");
            
            StateOwner.Nutrition += 10;
            
            StateOwner.IsInAction = false;
        }
    }
}
