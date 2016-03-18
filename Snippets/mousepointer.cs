// we maken de cursor texture static zodat iedereen de texture kan aanpassen
public Texture2D Cursor { get; set; }
public Vector2 CursorPos;

private void Initialize()
{
	Cursor = Content.Load<Texture2D>("bluecursor");
}

public void Update(GameTime gameTime)
{
	// muispositie uitlezen
	CursorPos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
}

<<<<<<< HEAD
		// verandering om merge conflict te veroorzaken
		// dit moet dus weg
		spriteBatch.Draw(error);

	}
}
=======
public void Draw(SpriteBatch spriteBatch)
{
	// teken de cursor op de muispositie
	spriteBatch.Draw(Cursor, CursorPos, Color.White);
}
>>>>>>> b785924bc64d7e7651def5b022d89930b232c28d
