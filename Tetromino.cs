using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace Tetris
{

  public class Tetromino : ICloneable
  {
    public bool Active { get; set; }
    public Shape Shape { get; private set; }
    public PieceType Type
    {
      get
      {
        return Shape.Type;
      }
      set { }
    }

    public Color Color
    {
      get
      {
        return Extensions.PieceTypeToColor(Shape.Type);
      }
      set { }
    }
    public int X, Y;

    public int Width
    {
      get
      {
        return Shape.GetShape.GetLength(1);
      }
    }

    public int Height
    {
      get
      {
        return Shape.GetShape.GetLength(0);
      }
    }

    void setup(Shape s)
    {
      this.Shape = s;
      X = 5 - Width / 2;
      Y = -2;
    }

    public Tetromino(Shape s)
    {
      setup(s);
    }

    public Tetromino()
    {
      setup(PieceGenerator.GetNextShape());
    }

    public Object Clone()
    {
      Tetromino t = (Tetromino)this.MemberwiseClone();
      t.Shape = this.Shape.ShallowCopy();
      return t;
    }

    public static void Fall(Tetromino tetromino)
    {
      tetromino.Y++;
    }

    public static void Rotate(Tetromino tetromino)
    {
      tetromino.Shape.Rotate();
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
      for (int row = 0; row < Shape.GetShape.GetLength(0); row++)
      {
        for (int col = 0; col < Shape.GetShape.GetLength(1); col++)
        {
          if (Shape.GetShape[row, col])
          {
            double x = X * GameConstants.GridWidth + (col * GameConstants.GridWidth);
            double y = Y * GameConstants.GridHeight + (row * GameConstants.GridHeight);
            SplashKit.FillRectangle(Color, x, y, GameConstants.GridWidth, GameConstants.GridHeight);
          }
        }
      }

    }
  }
}