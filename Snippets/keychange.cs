private KeyboardState	_oldstate;

public World (Game1 game)
{

}

public void Update(){
	KeyboardState newState = Keyboard.GetState();

	if(newState.IsKeyDown(Keys.Z) && _oldstate.IsKeyUp(Keys.Z))
	{
		// toets Z is ingedruk terwijl die hiervoor niet was ingedukt (staat is VERANDERD)
	}

	_oldstate = newState;
}