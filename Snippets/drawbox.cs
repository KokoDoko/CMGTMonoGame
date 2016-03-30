Texture2D box = new Texture2D(Game1.instance.GraphicsDevice, 1, 1);
box.SetData(new[] { Color.Yellow });

// Voor de rectangle kan de BoundingBox van het object gebruikt worden.
Game1.spriteBatch.Draw(box, new Rectangle(10,10,200,200), Color.White);
