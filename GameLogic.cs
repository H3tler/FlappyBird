using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlappyBird;

public static class GameLogic
{

    static bool keypressed, pausedPressed;
    static float charge;
    static float minspawnx;
    static float spawnx;
    public static int score;
    static bool hitwall;
    static Random ran;
    static bool Paused;

    static void ProgressGame()
    {
        List<Pole> polls = new();

        foreach (Pole paul in Paules) {
            if (paul.OffPos(0)) {
                continue;
            }
            if (paul.InPos(spawnx)) {
                var po = new Pole(pipeG);
                polls.Add(po);      
                UpdateSpawnRate();   
            }
            if (paul.CheckPass(Player.Xmin)) {
                score++;
                if (ran.Next(0, 2) == 1 && GameSpeed > -4f) GameSpeed += -0.1f;             
            }         

            paul.Move(new Vector2(GameSpeed, 0));
            polls.Add(paul);
        }

        Paules = polls;
    }

    static void UpdateSpawnRate()
    {
        if (spawnx < minspawnx) 
            spawnx += 10f; 
    }

    static void Collisions()
    {
        foreach (Pole paul in Paules) {
            if (paul.CheckCollision(Player)) {
                hitwall = true;
            }
        }

        if (Player.Ymin < 0) Player.Move(new Vector2(0, MathF.Abs(Player.Ymin)));

        if (Player.Ymin > Height) EndGame();
    }

    static async void PlayBirdAnimation() 
    {
        Player.Texture = bbu;
        await Task.Delay(50);
        Player.Texture = bbm;
        await Task.Delay(50);
        Player.Texture = bbd;
        await Task.Delay(50);
        Player.Texture = bbm;
    }

    static void EndGame()
    {
        if (score > HighScore) {
            HighScore = score;
            SaveHighScore();
        }
        GameOver = true;
    }

    public static void StartGame()
    {
        Paules = new();
        ran = new();
        score = 0;
        rotationangle = 10;  
        gravity = 0;                 
        GameSpeed = -2;
        Player = new (new Vector2(Width / 2, Height / 2), bbm.Width, bbm.Height, bbm);
        MaxHeight = Height - (Player.Height + 30);
        Paules.Add(new Pole(pipeG));
        GameOver = false;
        hitwall = false;
        keypressed = false;
        pausedPressed = false;
        Paused = false;
        spawnx = Width / 2;
        minspawnx = Width - pipeG.Width - 10;
        charge = -1.5f;
    }

    public static void UpdateGameState()
    {
         
        HandleKeys();

        if (GameOver == true || Paused == true) 
            return;        
         
        gravity += 0.1f;  

        Player.Move(new Vector2(0, gravity));  
        
        if (hitwall) {
            GameSpeed = 0;
            rotationangle = 75;
        }

        ProgressGame();
        Collisions();
    }

    static void HandleKeys()
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
            if (GameOver == false && hitwall == false && Paused == false) {
                gravity = charge;
                charge = -1.5f;
                PlayBirdAnimation();
            }                
        } 

        if (ks.IsKeyDown(Keys.Escape)) {
            pausedPressed = true;
        }   
        
        if (ks.IsKeyUp(Keys.Escape) && pausedPressed == true) {
            Paused = !Paused;
            pausedPressed = false;
        }
    }

    static void SaveHighScore()
    {    
        string dir = Directory.GetCurrentDirectory();
        string path = Path.Combine(dir, HSfileName);

        File.WriteAllText(path, HighScore.ToString());
    }

    public static void LoadHighScore()
    {
        string dir = Directory.GetCurrentDirectory();
        string path = Path.Combine(dir, HSfileName);
        
        if (! File.Exists(path)) {
            HighScore = 0;
            return;
        }

        HighScore = Convert.ToInt32(File.ReadAllText(path));

    }

}