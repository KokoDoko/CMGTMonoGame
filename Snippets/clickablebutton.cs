public class Button : GameObject
{
    private GameObject _target;
    private MouseState _previousMouse;
    private MouseState _mouse;

    public Button(Vector2 position, GameObject target) {
        _target = target;
        Texture = Game1.instance.Content.Load<Texture2D>("buttontexture");
        Position = position;
    }

    //
    // de update functie checkt of de muis binnen de bounds is, en is ingedrukt
    //
    public override void Update(GameTime gameTime){
        _mouse = Mouse.GetState();

        bool mouseHit = (Bounds.Contains(_mouse.X, _mouse.Y));
        bool mouseClicked = (_mouse.LeftButton != _previousMouse.LeftButton && _mouse.LeftButton == ButtonState.Pressed);

        // ALS de mous binnen de bounds is, EN de button state is PRESSED, EN de button state WAS NIET pressed, dan is het een click
        if(mouseHit && mouseClicked) {
            Console.Writeline("the button was clicked");
            // optioneel: de button roept een functie van een ander game object aan
            _target.DoSomething();
        }

        _previousMouse = _mouse;
    }
}
