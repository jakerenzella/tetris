using System;
using System.Collections.Generic;
using System.Linq;
using SplashKitSDK;

namespace Tetris
{
  public static class Extensions
  {
    public static Color PieceTypeToColor(PieceType type)
    {
      switch (type)
      {
        case PieceType.I:
          return Color.Cyan;
        case PieceType.L:
          return Color.Orange;
        case PieceType.J:
          return Color.Blue;
        case PieceType.O:
          return Color.Yellow;
        case PieceType.S:
          return Color.Green;
        case PieceType.T:
          return Color.Purple;
        case PieceType.Z:
          return Color.Red;
        case PieceType.Empty:
          return Color.Transparent;
        default: return Color.White;
      }
    }
    private static Random rng = new Random();
    public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
    {
      return listToClone.Select(item => (T)item.Clone()).ToList();
    }

    public static void Shuffle<T>(this List<T> list)
    {
      int n = list.Count;
      while (n > 1)
      {
        n--;
        int k = rng.Next(n + 1);
        T value = list[k];
        list[k] = list[n];
        list[n] = value;
      }
    }
  }

}

