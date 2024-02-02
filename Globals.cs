using System.Collections.Generic;

namespace FlappyBird;

public static class Globals // Class for global methods and variables.
{
    public static int Height;
    public static int Width;
    public static float GameSpeed;
    public static float gravity;
    public static int MaxHeight;
    public static Bird Player;
    public static List<Pole> Paules;
    public static bool GameOver = true;
    public static int polewidth = 100;
    public static Texture2D pixel1;
    public static Texture2D pixel2;
    public static Texture2D ground;
    public static Texture2D pipeG;
    public static Texture2D bbu, bbm, bbd;
    public static Texture2D startbutton, quitbutton;
    public static Texture2D[] numTextures = new Texture2D[10];
    public static float rotationangle;
    public static SpriteFont Consolas;
    public static int HighScore;
    public static string HSfileName = "Flappy_Bird_High_Score.txt";
}

