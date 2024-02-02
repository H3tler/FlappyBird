global using static FlappyBird.Globals;
global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Graphics;
global using Microsoft.Xna.Framework.Input;
using static FlappyBird.GameLogic;
using System;

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
        Consolas = Content.Load<SpriteFont>("Consolas");
        numTextures[0] = Content.Load<Texture2D>("0");
        numTextures[1] = Content.Load<Texture2D>("1");
        numTextures[2] = Content.Load<Texture2D>("2");
        numTextures[3] = Content.Load<Texture2D>("3");
        numTextures[4] = Content.Load<Texture2D>("4");
        numTextures[5] = Content.Load<Texture2D>("5");
        numTextures[6] = Content.Load<Texture2D>("6");
        numTextures[7] = Content.Load<Texture2D>("7");
        numTextures[8] = Content.Load<Texture2D>("8");
        numTextures[9] = Content.Load<Texture2D>("9");
        
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
        DisplayScore();
        spriteBatch.Draw(ground, new Rectangle(0, Height - 100, Width, 100), Color.White);
        foreach (Pole pp in Paules) {
            pp.Draw(spriteBatch);
        }
        Player.Draw(spriteBatch, gravity);      
        //spriteBatch.DrawString(Consolas, charge.ToString(), new Vector2(300, 300), Color.Black);      
//----------------------------------------------------------
        spriteBatch.End();

        base.Draw(gameTime);
    }

    private void DisplayScore() 
    {
        string ss = score.ToString();
        int st = 20;
        int between = 1;
        int difference = 0;

        foreach (char s in ss) {
            int index = Convert.ToInt32(s.ToString());
            Texture2D textore = numTextures[index];
            spriteBatch.Draw(textore, new Vector2(st + difference, 20), Color.White);
            difference += between + textore.Width;
        }

    }
}
