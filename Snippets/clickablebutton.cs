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
	private Button btn1;

	protected override void Initialize()
	{
		base.Initialize();

		// texture voor cursor
		Game1.Cursor = Content.Load<Texture2D>("bluecursor");

		// demo textures
		Texture2D button_OFF = Content.Load<Texture2D>("button_off");
		Texture2D button_ON = Content.Load<Texture2D>("button_on");
		Texture2D button_OVER = Content.Load<Texture2D>("button_over");

		btn1 = new Button(new Vector2(180, 340), button_OFF, button_ON, button_OVER);
	}

	protected override void Update(GameTime gameTime)
	{
		// muispositie uitlezen
		CursorPos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

		btn1.Update(gameTime);
	}


	protected override void Draw(GameTime gameTime)
	{
		// teken een button
		btn1.Draw(spriteBatch);

		// teken de cursor op de muispositie
		spriteBatch.Draw(Game1.Cursor, CursorPos, Color.White);

	}
}
// *********************************************************************************************************************
//
//	BUTTON.CS
//
// *********************************************************************************************************************

// de button verandert de mouse cursor als de muis eroverheen beweegt of klikt
class Button : GameObject
{
    // generic button functions
    private MouseState _previousMouse;
    private MouseState _mouse;
    private Texture2D _texture_off;
    private Texture2D _texture_on;
    private Texture2D _hovercursor;

    // base constructor for most buttons
    public Button(Vector2 pos, Texture2D off, Texture2D on, Texture2D hovercursor) 
        : base(pos) {

        _texture_off = off;
        _texture_on = on;
        _hovercursor = hovercursor;

        // set starting texture
        Texture = _texture_off;
    }


    public override void Update(GameTime gameTime) {
        // ALLEEN TEXTURE-CHANGE AANROEPEN BIJ VERANDERING TOV VORIGE STATUS
        _mouse = Mouse.GetState();

        bool bHover = (Bounds.Contains(_mouse.X, _mouse.Y));
        bool bPreviousHover = (Bounds.Contains(_previousMouse.X, _previousMouse.Y));
        bool bHoverChanged = (bHover != bPreviousHover);
        bool bPressChanged = (_mouse.LeftButton != _previousMouse.LeftButton);
        
        // HOVER : CHANGE CURSOR TEXTURE - override checkhover om iets anders te doen
        if (bHoverChanged)
            UpdateHoverCursor(bHover);

        // PRESS CAN CHANGE WHILE HOVER HAS NOT CHANGED - SWITCH BUTTON TEXTURE
        if (bPressChanged && bHover) 
            UpdatePressedCursor(_mouse.LeftButton == ButtonState.Pressed);

        // PRESSED: EXECUTE AN ACTION
        if (bHover && _mouse.LeftButton == ButtonState.Pressed && _previousMouse.LeftButton == ButtonState.Released)
            ExecuteButtonAction();
        

        _previousMouse = _mouse;
    }

    //
    // HOVER, PRESS AND CLICK ACTION
    //
    public void UpdateHoverCursor(bool bHover) {
        Game1.Cursor = bHover ? _hovercursor : Assets.C_POINTER;
    }

    // PRESSED CHANGES BUTTON TEXTURE (note: release outside is not detected)
    public void UpdatePressedCursor(bool bPressed) {
        Texture = (bPressed) ? _texture_on : _texture_off;
    }

    // override als je een button actie wil toevoegen
    public void ExecuteButtonAction() {
       
    }

}