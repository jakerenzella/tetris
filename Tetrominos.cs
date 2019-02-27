using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace Tetris
{
  public class Tetrominos
  {
    private List<Tetromino> _tetrominos;

    public Tetrominos()
    {
      _tetrominos = new List<Tetromino>();
    }

    public void RotateRight()
    {

    }

    public void AddTetromino()
    {
      _tetrominos.Add(new Tetromino());
    }

    public void Update()
    {
      foreach (Tetromino t in _tetrominos)
      {
        t.Update();
      }
    }

    public void Draw()
    {
      foreach (Tetromino t in _tetrominos)
      {
        t.Draw();
      }
    }

  }

  public class Tetromino
  {
    private double _fallingSpeed = 0.22;
    public bool Active { get; set; }
    public Color clr { get; private set; }
    public bool[,] shape;
    public double X, Y;
    private Direction direction;

    private enum Direction
    {
        North, East, South, West
    }

    public Tetromino()
    {
      X = 5;
      Y = 0;
      Active = true;

      shape = new bool[,] // O
                {
                    { true, true, true },
                    { true, true, false }
                };
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
      if (Active)
      {
        Y ++;
      }
      // Console.WriteLine(location.Y);

      // if (_getBottomPosition() <= 0)
      // {
      //   Active = false;
      // }
    }

    public void Draw()
    {
      for (int row = 0; row < shape.GetLength(0); row++)
      {
        for (int col = 0; col < shape.GetLength(1); col++)
        {
          if (shape[row, col])
          {
            double x = X * GameConstants.GameWidth + (col * GameConstants.GameWidth);
            double y = Y * GameConstants.GameHeight + (row * GameConstants.GameHeight);
            SplashKit.FillRectangle(Color.Red, x, y, GameConstants.GameWidth, GameConstants.GameHeight);
          }
        }
      }

    }
  }
}