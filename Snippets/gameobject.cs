// ************************************************************
// VOORBEELDCLASS DIE ERFT VAN GAMEOBJECT
// ************************************************************
public class Rock : GameObject
{
    public Rock(Vector2 position) : base(position)
    {

    }      
}


// ************************************************************
// GAMEOBJECT VOOR MONOGAME
// ************************************************************
public abstract class GameObject
{
    public Texture2D Texture    { get; set; }
    public Vector2   Position   { get; set; }
    public Color     Color      { get; set; }
    public float     Rotation   { get; set; } 
    public Vector2   Origin     { get; set; } 
    public float     Scale      { get; set; }

    public Rectangle Bounds
    {
        get
        {
            return new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                (int)(Texture.Width * Scale),
                (int)(Texture.Height * Scale));
        }
    }

    public GameObject(Vector2 position)
    {
        Position = position;
        Scale    = 1; 
        Color    = Color.White;
    }

	public virtual void Update(){
	
	}

    public virtual void Draw()
    {
        Game1.spriteBatch.Draw(
            Texture,
            Position,
            null,
            Color,
            Rotation,
            Origin,
            Scale,
            SpriteEffects.None,
            0
            );
    }
}
