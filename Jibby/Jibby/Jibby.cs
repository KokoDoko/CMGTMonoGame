using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JibbyIsMyFriend
{
    public class Jibby : GameObject
    {
        private MouseState _prevMouseState;
        private Idle _idleState;
        // TODO Je zou bij de invoer (set) nog een max kunnen aangeven
        public int Hygiene { get; set; }
        public int Nutrition { get; set; }
        public int Satisfaction { get; set; }

        public bool IsInAction { get; set; }

        public JibbyEmotionalStates State { get; set; }
        public AbstractAction ActionState { get; set; }

        public Queue<AbstractAction> ActionQueue { get; set; }

        public Jibby(Vector2 position)
            : base(position)
        {

            ActionQueue = new Queue<AbstractAction>();

            _idleState = new Idle(this);

            Hygiene = 20;
            Nutrition = 10;
            Satisfaction = 15;
        }

        public override void Update()
        {
            State = JibbyEmotionalStates.Happy;

            if (Nutrition < 5) State = JibbyEmotionalStates.Hungry;
            if (Hygiene < 5) State = JibbyEmotionalStates.Dirty;
            if (Satisfaction < 10) State = JibbyEmotionalStates.Sad;

            if (Hygiene == 0 || Nutrition == 0 || Satisfaction == 0)
            {
                State = JibbyEmotionalStates.Dead;
                // TODO GAME OVER
                if (ActionQueue.Count == 0) _idleState.Terminate();
            }

            // Wanneer Jibby niet in een actie actief is
            if (!IsInAction)
            {
                // Maar er zijn nog wel acties in de queue
                if (ActionQueue.Count > 0) ExecuteNextActionInQueue(); // Voer deze dan uit

                Texture = AssetsManager.Textures[State];
            }
            else
            {
                Texture = AssetsManager.ActionTextures[ActionState.GetType().Name];
            }

            MouseState mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Pressed && _prevMouseState.LeftButton == ButtonState.Released)
            {
                if (BoundingBox.Contains(mouse.X, mouse.Y))
                {
                    Satisfaction++;
                }
            }

            _prevMouseState = mouse;
        }

        public override void Draw()
        {
            // Origin wordt geset zodat jibby vanuit de onderkant getekend wordt ipv de linkerbovenhoek.
            Origin = new Vector2(Texture.Width / 2, Texture.Height);

            Game1.spriteBatch.DrawString(AssetsManager.Verdana, Hygiene.ToString(),        new Vector2(200, 70), Color.Black);
            Game1.spriteBatch.DrawString(AssetsManager.Verdana, Nutrition.ToString(),      new Vector2(320, 70), Color.Black);
            Game1.spriteBatch.DrawString(AssetsManager.Verdana, Satisfaction.ToString(),   new Vector2(450, 70), Color.Black);
            Game1.spriteBatch.Draw(Texture, Position - Origin, Color.White);
        }

        public void Age()
        {
            Hygiene--;
            Nutrition--;
            Satisfaction--;
        }

        public void ExecuteNextActionInQueue()
        {
            // Dequeue, geeft het volgende item uit de queue terug en verwijdert deze uit de lijst
            ActionState = ActionQueue.Dequeue();
            ActionState.Execute();
        }

        public void AddAction(AbstractAction action)
        {
            // Als Jibby dood is, mag hij niks meer doen
            if (State != JibbyEmotionalStates.Dead)
            {
                ActionQueue.Enqueue(action);
            }
        }
    }
}
