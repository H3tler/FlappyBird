using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlappyBird;

public static class GameLogic
{

    static bool keypressed;
    static float charge;
    static float minspawnx = Width - pipeG.Width - 10;
    static float spawnx = Width / 2;
    public static int score;

    public static void ProgressGame()
    {
        List<Pole> polls = new();

        foreach (Pole paul in Paules) {
            if (paul.OffPos(0)) {
                continue;
            }
            if (paul.InPos(spawnx)) {
                var po = new Pole(pipeG);
                polls.Add(po);      
                if (spawnx < minspawnx) spawnx += 10f;     
            }
            if (paul.CheckPass(Player.Position.X - (Player.Width / 2)))
                score++;

            paul.Move(new Vector2(GameSpeed, 0));
            polls.Add(paul);
        }

        Paules = polls;
    }

    public static void Collisions()
    {
        foreach (Pole paul in Paules) {
            if (paul.CheckCollision(Player)) GameOver = true;
        }

        if (Player.Position.Y - (Player.Height / 2) > Height) GameOver = true;
    }

    public static async void PlayBirdAnimation() 
    {
        Player.Texture = bbu;
        await Task.Delay(50);
        Player.Texture = bbm;
        await Task.Delay(50);
        Player.Texture = bbd;
        await Task.Delay(50);
        Player.Texture = bbm;
    }

    public static void StartGame()
    {
        Paules = new();
        score = 10;
        rotationangle = 10;  
        gravity = 0;                 
        GameSpeed = -2;
        Player = new (new Vector2(Width / 2, Height / 2), bbm.Width, bbm.Height, bbm);
        MaxHeight = Height - (Player.Height + 30);
        Paules.Add(new Pole(pipeG));
        GameOver = false;
        keypressed = false;
        charge = -1.5f;
    }

    public static void UpdateGameState()
    {
        
        HandleKeys();

        gravity += 0.1f;

        Player.Move(new Vector2(0, gravity));

        if (GameOver) {
            rotationangle = 75;
        } 
        
        if (! GameOver) ProgressGame();

        Collisions();
    }

    public static void HandleKeys()
    {
        var ks = Keyboard.GetState();

        if (ks.IsKeyDown(Keys.Space)) {
            keypressed = true;
            if (charge > -3f) {
                charge += -0.1f;
            }
        }

        if (ks.IsKeyUp(Keys.Space) && keypressed == true) {
            keypressed = false;
            if (! GameOver) {
                gravity = charge;
                charge = -1.5f;
                PlayBirdAnimation();
            }                
        }    

        if (ks.IsKeyDown(Keys.Q)) 
            StartGame(); 
    }

}