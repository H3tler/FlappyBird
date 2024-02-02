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
    Button start, quit;

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
        LoadHighScore();
        start = new(startbutton, new Vector2(Width / 2, 200), StartGame);
        quit = new(quitbutton, new Vector2(Width / 2, 320), Exit);
            
//----------------------------------------------------------

        base.Initialize();
    }

    protected override void LoadContent() {}

    void LoadTheContent() 
    {
        pipeG = Content.Load<Texture2D>("pipeG");
        ground = Content.Load<Texture2D>("base");
        bbm = Content.Load<Texture2D>("bbm");
        bbu = Content.Load<Texture2D>("bbu");
        bbd = Content.Load<Texture2D>("bbd");
        startbutton = Content.Load<Texture2D>("start");
        quitbutton = Content.Load<Texture2D>("quit");
        for (int i = 0; i < 10; i++) {
            numTextures[i] = Content.Load<Texture2D>($"{i}");
        }
        Consolas = Content.Load<SpriteFont>("Consolas");
        
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            Exit();

//----------------------------------------------------------
        if (GameOver) {
            start.Update();
            quit.Update();
        }
        else {
            UpdateGameState();
        }
//----------------------------------------------------------

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin();
//----------------------------------------------------------     
        spriteBatch.Draw(ground, new Rectangle(0, Height - 100, Width, 100), Color.White);

        if (! GameOver) {
            foreach (Pole pp in Paules) {
                pp.Draw(spriteBatch);
            }
            Player.Draw(spriteBatch, gravity);    
            DisplayNum(score, new Vector2(20, 20));  
        }
        else {
            start.Draw(spriteBatch);
            quit.Draw(spriteBatch);
            spriteBatch.DrawString(Consolas, "High Score :", new Vector2(5, 20),
            Color.Black, 0f, new Vector2(0, 0),
            1f, SpriteEffects.None, 0f);
            DisplayNum(HighScore, new Vector2(5, 60));
        }
           
//----------------------------------------------------------
        spriteBatch.End();

        base.Draw(gameTime);
    }

    private void DisplayNum(int num, Vector2 pos) 
    {
        string ss = num.ToString();
        int between = 1;
        int difference = 0;

        foreach (char s in ss) {
            int index = Convert.ToInt32(s.ToString());
            Texture2D textore = numTextures[index];
            spriteBatch.Draw(textore, new Vector2(pos.X + difference, pos.Y), Color.White);
            difference += between + textore.Width;
        }

    }
}
