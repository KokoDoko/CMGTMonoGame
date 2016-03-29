using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JibbyIsMyFriend
{
    class ButtonWash : Button
    {
        public ButtonWash(Vector2 position, Jibby jibby)
            : base(position, jibby)
        {
            mouseUpButton   = AssetsManager.ButtonWashingUp;
            mouseDownButton = AssetsManager.ButtonWashingDown;
        }

        protected override void ButtonAction()
        {
            Jibby.AddAction(new Washing(Jibby));
        }
    }
}
