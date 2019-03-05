using SplashKitSDK;
using System.Collections.Generic;

namespace Tetris
{
  public class Shape
  {
    public Shape ShallowCopy()
    {
      return (Shape)this.MemberwiseClone();
    }
    public Color Color;
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