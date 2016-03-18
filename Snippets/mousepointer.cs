// cursor texture en positie
public Texture2D Cursor { get; set; }
public Vector2 CursorPos;

private void Initialize()
{
	// dit is de dev branch waarin gewoon andere dingen staan
	Cursor = Content.Load<Texture2D>("bluecursormansditwerktniet_jemig");
}

public void Update(OrkTime gameTime, ork, goblin, kobold)
{
	// muispositie uitlezen
	CursorPos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

}
public void Draw(SpriteBatch spriteBatch)
{
	// teken de cursor op de muispositie
	spriteBatch.Draw(Cursor, CursorPos, Color.White);
}
