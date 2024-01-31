using System;
using System.Collections.Generic;

namespace FlappyBird;

public static class GameLogic
{


    public static void ProgressGame()
    {
        List<Pole> polls = new();

        foreach (Pole paul in Paules) {
            if (paul.OffPos(0)) {
                continue;
            }
            if (paul.InPos(600)) {
                var po = new Pole(pixel2);
                polls.Add(po);           
            }
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
    }

}