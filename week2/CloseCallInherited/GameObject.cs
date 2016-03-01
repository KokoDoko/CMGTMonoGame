using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloseCallInherited
{
    class GameObject
    {
        private const bool DEBUG = false;

        public Texture2D    Texture     { get; set; }
        public Vector2      Position    { get; set; }
        public Color        Color       { get; set; }
        public float        Scale       { get; set; }

        // Childs van GameObject kunnen deze properties overschrijven
        public virtual Vector2  Origin      { get; set; }
        public virtual float    Rotation    { get; set; }

        public virtual Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                        (int)(Position.X - (Origin.X * Scale)),
                        (int)(Position.Y - (Origin.Y * Scale)),
                        (int)(Texture.Width * Scale),
                        (int)(Texture.Height * Scale));
            }
        }

        public GameObject()
        {
            Color = Color.White;
            Scale = 1;
        }

        /// <summary>
        /// Every GameObject has a update function but the childs can implement logic
        /// </summary>
        public virtual void Update()
        {
            
        }

        public virtual void Draw()
        {
            if (DEBUG)
            {
                // Stukje code om de boundingboxen te kunnen tekenen voor debud doeleinden
                Texture2D text = new Texture2D(Game1.instance.GraphicsDevice, 1, 1);
                text.SetData(new[] { Color.Yellow });

                Game1.spriteBatch.Draw(text, Bounds, Color.White);
            }

            Game1.spriteBatch.Draw(
                Texture, 
                Position, 
                null, 
                Color, 
                Rotation, 
                Origin, 
                Scale, 
                SpriteEffects.None, 
                0);
        }
    }
}
