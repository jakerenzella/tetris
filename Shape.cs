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
    public bool [,] Blocks;
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
      SuperRotate();
    }

    public void SuperRotate() {
      int height = Blocks.GetLength(0);
      int width = Blocks.GetLength(1);
      bool [,] newBlocks = new bool[height,width];
      for (int x = 0; x < width; x++) {
        for (int y = 0; y < height; y++) {
          newBlocks[y, height - (x+1)] = Blocks[x,y];
        }
      }
      Blocks = newBlocks;
    }
  }
}