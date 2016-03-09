private Random _random;

public World()
{
    // RANDOM GENERATOR AANMAKEN
    _random = new Random();
           
}

private void GenerateRandomThings()
{

    //
    // random getal (int) tussen 1 en 6
    //
    int randomJunk = _random.Next(1, 6);

    //
    // random getal (float) tussen 0.0 en 1.0
    //
    float randomAppearance = _random.NextDouble();

    // als kleiner dan 0.02 --- betekent een kans van 2 procent
    if (randomAppearance < 0.02f)
    {

    }



    //
    // random positie op het scherm
    //
    Vector2 pos = new Vector2(_random.Next(0, 1000), _random.Next(0, 800));


}