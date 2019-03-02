using System;
using SplashKitSDK;

namespace Tetris
{

  public class Game
  {
    private Timer timer;
    private bool[,] grid;
    private Tetromino _tetromino;
    private int ticks;

    public Game()
    {
      grid = new bool[10, 20];
      _tetromino = new Tetromino();
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
          SplashKit.DrawRectangle(Color.Gray, x * GameConstants.GridWidth, y * GameConstants.GridHeight, GameConstants.GridWidth, GameConstants.GridHeight);
          if (!grid[x, y])
          {
          }
          _tetromino.Draw();
        }
      }
    }

// Delegate?
    private bool _checkValidMove()
    {
      Tetromino testTetromino = (Tetromino)_tetromino.Clone();
      testTetromino.Update();
      return !_collision(testTetromino);
    }

    private bool _collision(Tetromino tetromino)
    {
      for (int row = 0; row < tetromino.Shape.GetLength(0); row++)
      {
        for (int col = 0; col < tetromino.Shape.Rank; col++)
        {
          Console.WriteLine($"Row: {row}, col: {col}");
          Console.WriteLine($"Grid row: {row + tetromino.X}, grid col: {col + tetromino.Y}");
          Console.WriteLine($"X: {tetromino.X}, Y: {tetromino.Y}");

          if (col + tetromino.Y >= 20)
          {
            Console.WriteLine("Below Screen");
            return true;
          }
          if (tetromino.Shape[row, col] && grid[row + tetromino.X, col + tetromino.Y])
          {
            Console.WriteLine("This shouldn't happen");
            return true;
          }
        }
      }
      return false;
    }

    public void _killTetromino()
    {

    }

    public void Update()
    {
      if ((((int)timer.Ticks) / 1000) >= ticks)
      {

        if (_checkValidMove())
        {
          Console.WriteLine("Valid");
          _tetromino.Update();
        }

        ticks++;
      }
    }
  }
}