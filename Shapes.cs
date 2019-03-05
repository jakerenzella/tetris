using System;
using System.Collections.Generic;

namespace Tetris
{
  public static class Shapes
  {
    private static Random rng = new Random();

    public static bool[,] GetRandomShape()
    {
      return _tetrisFigures[rng.Next(_tetrisFigures.Count)];
    }

    private static List<bool[,]> _tetrisFigures = new List<bool[,]>()
    {
      new bool[,] // ----
      {
        { true, true, true, true }
      },
      new bool[,] // O
      {
        { true, true },
        { true, true }
      },
      new bool[,] // T
      {
      { false, true, false },
      { true, true, true },
      },
      new bool[,] // S
      {
        { false, true, true, },
        { true, true, false, },
      },
      new bool[,] // Z
      {
        { true, true, false },
        { false, true, true },
      },
      new bool[,] // J
      {
        { true, false, false },
        { true, true, true }
      },
      new bool[,] // L
      {
        { false, false, true },
        { true, true, true }
      },
    };
  }
}