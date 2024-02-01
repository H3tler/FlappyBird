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
        
        LoadTheContent();
        StartGame();
        
//----------------------------------------------------------

        base.Initialize();
    }

    protected override void LoadContent() {}

    void LoadTheContent() 
    {
        pixel1 = new (GraphicsDevice, 1, 1);
        pixel1.SetData(new Color[] {Color.Blue});
        pixel2 = new (GraphicsDevice, 1, 1);
        pixel2.SetData(new Color[] {Color.Green});
        pipeG = Content.Load<Texture2D>("pipeG");
        ground = Content.Load<Texture2D>("base");
        bbm = Content.Load<Texture2D>("bbm");
        bbu = Content.Load<Texture2D>("bbu");
        bbd = Content.Load<Texture2D>("bbd");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            Exit();

//----------------------------------------------------------
        UpdateGameState();
//----------------------------------------------------------

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin();
//----------------------------------------------------------
        spriteBatch.Draw(ground, new Rectangle(0, Height - 100, Width, 100), Color.White);
        foreach (Pole pp in Paules) {
            pp.Draw(spriteBatch);
        }
        Player.Draw(spriteBatch, gravity);            
//----------------------------------------------------------
        spriteBatch.End();

        base.Draw(gameTime);
    }
}
