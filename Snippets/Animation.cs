using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;

namespace SpriteAnimation
{
    public class Animation
    {
        // CONSTANTS
        private const bool DEBUG            = true;
        private const int  WIDTH            = 161;
        private const int  HEIGHT           = 161;
        private const int  NUMBER_OF_FRAMES = 3;
        
        // FIELDS
        private int         _animationSpeed = 10;
        private int         _currentFrame;
        private Texture2D   _texture;
        private Vector2     _position;
        private int         _animationCounter;
        

        // PROPERTIES

        /// <summary>
        /// Dit geeft de huidige rectangle terug die 
        /// getekend moet worden van de totale SpriteSheet
        /// </summary>
        private Rectangle _currentRectangle
        {
            get
            {
                return new Rectangle(
                    WIDTH * _currentFrame,
                    0,
                    WIDTH,
                    HEIGHT
                    );
            }
        }

        /// <summary>
        /// De boundingbox van het schip
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                    (int)_position.X,
                    (int)_position.Y,
                    WIDTH,
                    HEIGHT
                    );
            }
        }

        // CONSTRUCTOR
        public Animation(Texture2D texture, Vector2 position)
        {
            _texture    = texture;
            _position   = position;
        }

        // METHODS
        public void Update()
        {
            _animationCounter++;

            if (_animationCounter % _animationSpeed == 0)
            {
                // Ga telkens een frame verder
                _currentFrame++; 
            }

            // Als laatste frame in de animatie bereikt is
            if (_currentFrame > NUMBER_OF_FRAMES)
            {
                // ga terug naar eerste frame
                _currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice gd)
        {
            // START DEBUG INFORMATIE---------------------------------
            if (DEBUG)
            {
                Texture2D text = new Texture2D(gd, 1, 1);
                text.SetData(new[] { Color.Yellow });

                //spriteBatch.Draw(text, _currentRectangle, Color.White); 
                spriteBatch.Draw(text, Bounds, Color.White); 
            }
            // END DEBUG INFORMATIE-----------------------------------

            

            // Teken van de SpriteSheet alleen currentRectangle
            spriteBatch.Draw(
                _texture, 
                _position,
                _currentRectangle,
                Color.White,
                0,
                new Vector2(0, 0),
                1,
                SpriteEffects.None,
                0);
        }

    }
}
