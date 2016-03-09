private SoundEffect 	_meow;

public World (Game1 game)
{
	_meow = game.Content.Load<SoundEffect>("meow1");

	PlaySound(0.2f);
}

private void PlaySound(float toonHoogte){
	float volume = 1.0f;
	float pan = 0.0f;
	_meow.Play(volume, toonHoogte, pan);
}