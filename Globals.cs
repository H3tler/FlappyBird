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
    public static List<Pole> Paules = new();
    public static bool GameOver = false;
    public static int polewidth = 300;
    public static Texture2D pixel1;
    public static Texture2D pixel2;
}

