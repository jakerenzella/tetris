using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace Tetris
{
  public class Tetromino : ICloneable
  {
    public bool Active { get; set; }
    public Color clr { get; private set; }
    public bool[,] Shape { get; private set; }
    public int X, Y;

    public int Width
    {
      get
      {
        return Math.Max(Shape.GetLength(0), Shape.GetLength(1));
      }
    }

    public int Height
    {
      get
      {
        return Shape.Rank;
      }
    }

    public Tetromino()
    {
      X = 2;
      Y = 0;

      Shape = new bool[,]
      {
          { true, true, true, true, true },
          { false, false, false, false, false }
      };
    }

    public object Clone()
    {
      return this.MemberwiseClone();
    }

    public static void Fall(Tetromino tetromino)
    {
      tetromino.Y++;
    }

    public static void MoveLeft(Tetromino tetromino)
    {
      tetromino.X--;
    }

    public static void MoveRight(Tetromino tetromino)
    {
      tetromino.X++;
    }

    public void Draw()
    {
      for (int row = 0; row < Shape.GetLength(0); row++)
      {
        for (int col = 0; col < Shape.GetLength(1); col++)
        {
          if (Shape[row, col])
          {
            double x = X * GameConstants.GridWidth + (col * GameConstants.GridWidth);
            double y = Y * GameConstants.GridHeight + (row * GameConstants.GridHeight);
            SplashKit.FillRectangle(Color.Red, x, y, GameConstants.GridWidth, GameConstants.GridHeight);
          }
        }
      }

    }
  }
}