namespace FlappyBird;

public class Bird
{
    public Vector2 Speed;
    private Texture2D Texture;
    public Vector2 Position {get; private set;}
    private int Width;
    private int Height;
    public bool Dead;
    public float Xmin {
        get {return Position.X - (Width / 2);}
    }
    public float Xmax {
        get {return Position.X + (Width / 2);}
    }
    public float Ymin {
        get {return Position.Y - (Height / 2);}
    }
    public float Ymax {
        get {return Position.Y + (Height / 2);}
    }

    public Bird(Vector2 Pos, int width, int height, Texture2D texture) 
    {
        Position = Pos;
        Width = width;
        Height = height;
        Texture = texture;
        Dead = false;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Position, new Rectangle {Width = Width, Height = Height}, Color.White, 0f,
        new Vector2(Width / 2, Height / 2), Vector2.One, SpriteEffects.None, 0f);
    }

    public void Move(Vector2 MovingVector) 
    {
        Position = Vector2.Add(Position, MovingVector);
    }
}