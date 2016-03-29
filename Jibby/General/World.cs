using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JibbyIsMyFriend
{
    public class World
    {
        private Jibby _jibby;
        private ButtonEat _eatButton;
        private ButtonWash _washButton;

        public World()
        {
            _jibby = new Jibby(new Vector2(315, 300));
            _eatButton = new ButtonEat(new Vector2(180, 350), _jibby);
            _washButton = new ButtonWash(new Vector2(350, 350), _jibby);
        }

        public void Draw()
        {
            Game1.spriteBatch.Draw(AssetsManager.Background, Vector2.Zero, Color.White);

            _jibby.Draw();
            _eatButton.Draw();
            _washButton.Draw();
        }

        public void Update()
        {
            _jibby.Update();
            _eatButton.Update();
            _washButton.Update();
        }
    }
}
