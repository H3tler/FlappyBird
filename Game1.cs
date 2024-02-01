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
        rotationangle = 10;
        pixel1 = new (GraphicsDevice, 1, 1);
        pixel1.SetData(new Color[] {Color.Blue});
        pixel2 = new (GraphicsDevice, 1, 1);
        pixel2.SetData(new Color[] {Color.Green});
        pipeG = Content.Load<Texture2D>("pipeG");
        ground = Content.Load<Texture2D>("base");
        bbm = Content.Load<Texture2D>("bbm");
        bbu = Content.Load<Texture2D>("bbu");
        bbd = Content.Load<Texture2D>("bbd");
        Player = new (new Vector2(Width / 2, Height / 2), bbm.Width, bbm.Height, bbm);
        MaxHeight = Height - (Player.Height + 30);
        paul = new(pipeG);
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
            if (! GameOver) {
                gravity = -2f;
                PlayBirdAnimation();
            }   
            else {
                rotationangle = 75;
            }    
        }

        gravity += 0.1f;

        Player.Move(new Vector2(0, gravity));
        
        if (!GameOver) ProgressGame();
        Collisions();
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
