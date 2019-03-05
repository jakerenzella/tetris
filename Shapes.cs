using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace Tetris
{
  public class Shape
  {
    public Color Color;
    public List<bool[,]> Rotations;
  }
  public static class Shapes
  {
    private static Random rng = new Random();
    public static Shape GetRandomShape()
    {
      return _tetrisFigures[rng.Next(_tetrisFigures.Count)];
    }

    private static List<Shape> _tetrisFigures = new List<Shape>()
    {
        new Shape
        {
          Color = Color.Cyan,
          Rotations = new List<bool[,]>() // ----
          {
            new bool[,] { { true, true, true, true } },
            new bool[,] { { true },
                          { true },
                          { true },
                          { true }
                        }
          }
        },

        new Shape
        {
          Color = Color.Blue,
          Rotations = new List<bool[,]>() // J
          {
            new bool[,] {
                          { true, false, false },
                          { true, true, true }
                        },

            new bool[,] {
                          { false, true, true },
                          { false, true, false },
                          { false, true, false }
                        },
            new bool[,] {
                          { false, false, false },
                          { true, true, true },
                          { false, false, true }
                        },
            new bool[,] {
                          { false, true, false },
                          { false, true, false },
                          { true, true, false }
          }
        },
        }
    };

    //   {
    //   new bool[,] // ----
    //   {
    //     { true, true, true, true }
    //   }
    //   },
    //   new bool[,] // O
    //   {
    //     { true, true },
    //     { true, true }
    //   },
    //   new bool[,] // T
    //   {
    //   { false, true, false },
    //   { true, true, true },
    //   },
    //   new bool[,] // S
    //   {
    //     { false, true, true, },
    //     { true, true, false, },
    //   },
    //   new bool[,] // Z
    //   {
    //     { true, true, false },
    //     { false, true, true },
    //   },
    //   new bool[,] // J
    //   {
    //     { true, false, false },
    //     { true, true, true }
    //   },
    //   new bool[,] // L
    //   {
    //     { false, false, true },
    //     { true, true, true }
    //   },
    // };
  };
}
