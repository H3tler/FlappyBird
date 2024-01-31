using System;

namespace FlappyBird;

public static class GameLogic
{


    public static void ProgressGame()
    {
        Random ran = new();

        foreach (Pole paul in Paules) {
            if (paul.OffScreen()) {
                Paules.Remove(paul);
                
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