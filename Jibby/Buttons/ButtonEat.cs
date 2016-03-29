using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JibbyIsMyFriend
{
    class ButtonEat : Button
    {
        public ButtonEat(Vector2 position, Jibby jibby)
            : base(position, jibby)
        {
            mouseUpButton   = AssetsManager.ButtonEatingUp;
            mouseDownButton = AssetsManager.ButtonEatingDown;
        }

        protected override void ButtonAction()
        {
            Jibby.AddAction(new Eating(Jibby));
        }
    }
}
