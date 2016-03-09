Texture2D box = new Texture2D(Game1.instance.GraphicsDevice, 1, 1);
box.SetData(new[] { Color.Yellow });

Game1.spriteBatch.Draw(box, Bounds, Color.White);