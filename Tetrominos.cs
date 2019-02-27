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
    public bool[] shape;
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

      // shape = new bool[8] { false, true, true, false, false, false, false, true };
    }

    // public int GridLocations { get {
      // return location.X
    // }}

    private double _getBottomPosition()
    {
      for (int i = 7; i > 3; i--)
      {
        if (shape[i])
        {
          return GameConstants.GridSize * 2 + (Y * GameConstants.GridSize);
        }
      }
      return Y;
    }


    public void Update()
    {
      if (Active)
      {
        Y += _fallingSpeed;
      }
      // Console.WriteLine(location.Y);

      if (_getBottomPosition() <= 0)
      {
        Active = false;
      }
    }

    public void Draw()
    {
      for (int i = 0; i < 4; i++)
      {
        if (shape[i])
        {
          SplashKit.FillRectangle(Color.DeepSkyBlue, X * 20 + (i * 20), Y * 20, 20, 20);
          SplashKit.DrawRectangle(Color.BlueViolet, X * 20 + (i * 20), Y * 20, 20, 20);
        }
      }
      for (int i = 0; i < 4; i++)
      {
        if (shape[i + 4])
        {
          SplashKit.FillRectangle(Color.DeepSkyBlue, X * 20 + (i * 20), Y * 20 + 20, 20, 20);
          SplashKit.DrawRectangle(Color.BlueViolet, X * 20 + (i * 20), Y * 20 + 20, 20, 20);
        }
      }
    }
  }
}