using SplashKitSDK;
using System;
using System.Collections.Generic;

namespace Tetris
{
  public class Shape : ICloneable
  {
    public Object Clone()
    {
      Shape s = this.ShallowCopy();
      return s;
    }
    public Shape ShallowCopy()
    {
      return (Shape)this.MemberwiseClone();
    }
    public PieceType Type;
    private int rotation = 0;
    public List<bool[,]> Rotations;
    public bool[,] GetShape
    {
      get
      {
        return Rotations[rotation];
      }
    }

    public void Rotate()
    {
      rotation = (rotation + 1) % (Rotations.Count);
    }
  }
}