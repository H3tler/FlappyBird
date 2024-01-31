using System.Collections.Generic;

namespace FlappyBird;

public class Pole
{
    public int Height {get; private set;}
    public int Width {get; private set;}
    private Texture2D Texture;
    public Vector2 Position {get; private set;}
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

    

    public Pole(int Width, int Height, Vector2 Position, Texture2D Texture) 
    {
        this.Width = Width;
        this.Height = Height;
        this.Position = Position;
        this.Texture = Texture;
    }

    public bool CheckCollision(Bird Player)
    {
        if (Player.Xmin > Xmax) 
            return false;
        if (Player.Xmax < Xmin) 
            return false;
        if (Player.Ymin > Ymax)
            return false;
        if (Player.Ymax < Ymin)
            return false;

        return true;
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

