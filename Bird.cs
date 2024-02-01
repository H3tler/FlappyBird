using System;

namespace FlappyBird;

public class Bird
{
    public Texture2D Texture;
    public Vector2 Position {get; private set;}
    public int Height {get; private set;}
    public int Width {get; private set;}
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
    }

    public void Draw(SpriteBatch spriteBatch, float dir)
    {
        float angle = rotationangle * (MathF.PI / 180);
        float rot = dir > 0 ?  angle : dir < 0 ? angle * -1: 0;
        spriteBatch.Draw(Texture, Position, new Rectangle {Width = Width, Height = Height}, Color.White, rot,
        new Vector2(Width / 2, Height / 2), Vector2.One, SpriteEffects.None, 0f);
    }

    public void Move(Vector2 MovingVector) 
    {
        Position = Vector2.Add(Position, MovingVector);
    }
}