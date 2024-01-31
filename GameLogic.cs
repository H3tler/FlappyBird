using System;

namespace FlappyBird;

public static class GameLogic
{


    public static void ProgressGame()
    {
        Random ran = new();

        foreach (Pole paul in Paules) {
            if (paul.Position.X + (paul.Width / 2) < 0) {
                Paules.Remove(paul);
                int height = ran.Next(100, MaxHeight);

                Paules.Add(new Pole(polewidth, height, new Vector2(Width + (polewidth / 2)), pixel2));
            }
        }
    }

    public static void Collisions()
    {
        foreach (Pole paul in Paules) {
            if (paul.CheckCollision(Player)) GameOver = true;
        }
    }

}