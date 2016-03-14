// *********************************************************************************************************************
//
//	WORLD.CS
//
// *********************************************************************************************************************

class World
{
	// we maken de cursor texture static zodat iedereen de texture kan aanpassen
	public static Texture2D Cursor { get; set; }
	public Vector2 CursorPos;

	protected override void Initialize()
	{
		base.Initialize();

		// texture voor cursor
		World.Cursor = Content.Load<Texture2D>("bluecursor");
	}

	protected override void Update(GameTime gameTime)
	{
		// muispositie uitlezen
		CursorPos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
	}


	protected override void Draw(GameTime gameTime)
	{
		// teken de cursor op de muispositie
		spriteBatch.Draw(World.Cursor, CursorPos, Color.White);

	}
}