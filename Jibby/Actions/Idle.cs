using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JibbyIsMyFriend
{
    class Idle : AbstractAction
    {
        public Idle(Jibby owner)
            : base(owner)
        {
            Execute();
        }

        public override void Execute()
        {
            // Toon de Idle-animatie
            
            //Bij de Idle state moet het event wel herhaalt worden
            Timer.AutoReset = true;

            StartTimer(1000);
            
            Debug.WriteLine("Standaard gedrag");
        }

        protected override void OnActionEnd()
        {
            // Er is geen volgende state
            StateOwner.Age();
        }

        public void Terminate()
        {
            Timer.Stop();
        }
    }
}
