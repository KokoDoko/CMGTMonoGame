using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloseCallInherited
{
    public class Menu
    {
        private Car _car;
        private Truck _truck;
        private SpriteFont _verdana;

        public Menu()
        {
            _car = new Car(new Vector2(200, 200), 0.5f, Color.Green);
            _truck = new Truck(new Vector2(400, 170), 0.15f, Color.Gray);
            _verdana = Game1.instance.Content.Load<SpriteFont>("Verdana");
        }

        public void Update()
        {
            KeyboardState kbs = Keyboard.GetState();

            // Handelt toetsenbord af (numeriek 1 en 2), voor keuze van voertuig
            if(kbs.IsKeyDown(Keys.D1))
            {
                Game1.instance.StartGame(1);
            }
            if (kbs.IsKeyDown(Keys.D2))
            {
                Game1.instance.StartGame(2);
            }
        }


        public void Draw()
        {
            Texture2D text = new Texture2D(Game1.instance.GraphicsDevice, 1, 1);
            text.SetData(new[] { new Color() { R = 100, G = 100, B = 100, A = 20 }});
            
            Game1.spriteBatch.DrawString(_verdana, "Pick your ride", new Vector2(300, 100), Color.White);

            Game1.spriteBatch.Draw(text, new Rectangle(190, 170, 150, 80), Color.White);
            _car.Draw();
            Game1.spriteBatch.DrawString(_verdana, "Press 1", new Vector2(200, 270), Color.White);

            Game1.spriteBatch.Draw(text, new Rectangle(390, 170, 150, 80), Color.White);
            _truck.Draw();
            Game1.spriteBatch.DrawString(_verdana, "Press 2", new Vector2(400, 270), Color.White);
        }
    }
}
