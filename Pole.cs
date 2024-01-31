using System.Collections.Generic;
using System;

namespace FlappyBird;

public class Pole
{
    private Texture2D Texture;
    Paul[] poles;

    internal class Paul
    {
        internal Vector2 Position;
        internal int Height;
        internal int Width;

        internal Paul(int width, int height, Vector2 Pos) {
            Width = width;
            Height = height;
            Position = Pos;
        }

        internal float Xmin {
            get {return Position.X - (Width / 2);}
        }
        internal float Xmax {
            get {return Position.X + (Width / 2);}
        }
        internal float Ymin {
            get {return Position.Y - (Height / 2);}
        }
        internal float Ymax {
            get {return Position.Y + (Height / 2);}
        }
    }

    public Pole(int width, int height, Vector2 Position, Texture2D Texture) 
    {
        Random ran = new Random();
        
        int height1 = ran.Next(100, MaxHeight - 200);
        int height2 = ran.Next(100, Height - (MaxHeight - 200));

        Paul PoleU = new(width, height1, new Vector2(Width + (width / 2), height1 / 2));
        Paul PoleD = new(width, height2, new Vector2(Width + (width / 2), Height - (height2 / 2)));
        poles = new Paul[] {PoleU, PoleD}; 
        

        this.Texture = Texture;
    }

    public bool CheckCollision(Bird Player)
    {
        bool collide = false;

        foreach (Paul pole in poles) {
            if (Player.Xmin > pole.Xmax) 
                continue;
            if (Player.Xmax < pole.Xmin) 
                continue;
            if (Player.Ymin > pole.Ymax)
                continue;
            if (Player.Ymax < pole.Ymin)
                continue;

            collide = true;
        }

        return collide;
    } 

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (Paul pole in poles) {
            spriteBatch.Draw(Texture, pole.Position, new Rectangle {Width = pole.Width, Height = pole.Height}, Color.White, 0f,
                new Vector2(pole.Width / 2, pole.Height / 2), Vector2.One, SpriteEffects.None, 0f);
        }
        
    }

    public bool OffScreen() 
    {
        foreach (Paul pole in poles) {
            if (pole.Position.X + (pole.Width / 2) < 0) return true;
        }

        return false;
    }

    public void Move(Vector2 MovingVector) 
    {
        foreach (Paul pole in poles) {
            pole.Position = Vector2.Add(pole.Position, MovingVector);
        }   
    }

}

