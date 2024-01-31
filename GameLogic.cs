using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                var po = new Pole(pipeG);
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

}