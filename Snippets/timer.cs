private float _elapsed;

public MyClass() {
    _elapsed = 0f;
}


public override void Update(GameTime gameTime){
    _elapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
    if(_elapsed > 5) {
        Console.WriteLine("er zijn 5 seconden voorbij");
        _elapsed = 0;
    }
}