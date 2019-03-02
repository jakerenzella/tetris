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

    // public int Width {
    //   get {
    //     return Shape.GetLength(0) + 1;
    //   }
    // }

    // public int Height {
    //   get {
    //     return Shape.GetLength(1) + 1;
    //   }
    // }

    public Tetromino()
    {
      X = 2;
      Y = 0;

      Shape = new bool[,] // O
                {
                    { true, true, true, true, true, true, true, true, true },
                    { false, false, false, true, true, false, false, false, false }
                };
    }

    public object Clone()
    {
      return this.MemberwiseClone();
    }

    // public int GridLocations { get {
    // return location.X
    // }}

    // private double _getBottomPosition()
    // {
    //   for (int i = 7; i > 3; i--)
    //   {
    //     if (shape[i])
    //     {
    //       return GameConstants.GridSize * 2 + (Y * GameConstants.GridSize);
    //     }
    //   }
    //   return Y;
    // }


    public void Update()
    {
      Y++;
      // Console.WriteLine(location.Y);

      // if (_getBottomPosition() <= 0)
      // {
      //   Active = false;
      // }
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