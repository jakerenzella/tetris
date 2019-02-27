using System;
using SplashKitSDK;

namespace Tetris
{

  public class Game
  {
    private Timer timer;
    private bool[,] grid;
    private Tetrominos tetrominos;
    private int ticks;

    public Game()
    {
      grid = new bool[10, 20];
      tetrominos = new Tetrominos();
      tetrominos.AddTetromino();
      ticks = 0;
      timer = new Timer("gametime");
      timer.Start();
    }

    public void Draw()
    {
      for (int x = 0; x < 10; x++)
      {
        for (int y = 0; y < 20; y++)
        {
          SplashKit.DrawRectangle(Color.Gray, x * GameConstants.GameWidth, y * GameConstants.GameHeight, GameConstants.GameWidth, GameConstants.GameHeight);
          if (!grid[x, y])
          {
          }
          tetrominos.Draw();
        }
      }
    }
    public void Update()
    {
      if ((((int)timer.Ticks) / 10) >= ticks)
      {
        tetrominos.Update();
        ticks++;
      }
    }
  }
}