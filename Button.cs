namespace  FlappyBird;

public class Button
{
    Texture2D texture;
    public Vector2 Position {get; private set;}
    int width;
    int height;
    public delegate void OnClick();
    public OnClick Click;
    bool clicked = false;
    float transparency = 1f;

    public Button(Texture2D Texture, Vector2 Pos, OnClick action) 
    {
        texture = Texture;
        Position = Pos;
        width = texture.Width;
        height = texture.Height;
        Click = action;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, Position, new Rectangle {Width = width, Height = height}, Color.White * transparency, 0f,
        new Vector2(width / 2, height / 2), Vector2.One, SpriteEffects.None, 0f);
    }

    public bool CheckCursor()
    {
        var ms = Mouse.GetState();

        if (ms.X < Position.X - (width / 2)) return false;
        if (ms.X > Position.X + (width / 2)) return false;
        if (ms.Y < Position.Y - (height / 2)) return false;
        if (ms.Y > Position.Y + (height / 2)) return false;

        return true;
    }

    public void Update()
    {
        var ms = Mouse.GetState();

        if (CheckCursor()) {
            if (ms.LeftButton == ButtonState.Pressed) clicked = true;
            if (ms.LeftButton == ButtonState.Released && clicked == true) {
                clicked = false;
                Click();
            }
            transparency = 0.5f;
        }
        else {
            transparency = 1f;
        }
    }
}