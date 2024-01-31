global using static FlappyBird.Globals;
global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Graphics;
global using Microsoft.Xna.Framework.Input;
using static FlappyBird.GameLogic;

namespace FlappyBird;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    Pole paul;
    bool keypressed = false;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        // TargetElapsedTime = new System.TimeSpan(Time you want); If you want to change the framerate.

        // Set the window size:
        graphics.PreferredBackBufferWidth = Width = 800;
        graphics.PreferredBackBufferHeight = Height = 500;
    }

    protected override void Initialize()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

//----------------------------------------------------------
        pixel1 = new (GraphicsDevice, 1, 1);
        pixel1.SetData(new Color[] {Color.Blue});
        pixel2 = new (GraphicsDevice, 1, 1);
        pixel2.SetData(new Color[] {Color.Green});
        Player = new (new Vector2(Width / 2, Height / 2), 30, 30, pixel1);
        MaxHeight = Height - (Player.Height + 30);
        paul = new(pixel2);
        Paules.Add(paul);

        GameSpeed = -2;
        
//----------------------------------------------------------

        base.Initialize();
    }

    protected override void LoadContent()
    {

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

//----------------------------------------------------------
        var ks = Keyboard.GetState();

        if (ks.IsKeyDown(Keys.Space) && keypressed == false) {
            keypressed = true;
        }
        if (ks.IsKeyUp(Keys.Space) && keypressed == true) {
            keypressed = false;
            gravity = -2f;
        }

        gravity += 0.1f;

        Player.Move(new Vector2(0, gravity));
        
        if (!GameOver) ProgressGame();
        //Collisions();
//----------------------------------------------------------

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin();
//----------------------------------------------------------
        foreach (Pole pp in Paules) {
            pp.Draw(spriteBatch);
        }
        Player.Draw(spriteBatch);       
//----------------------------------------------------------
        spriteBatch.End();

        base.Draw(gameTime);
    }
}
