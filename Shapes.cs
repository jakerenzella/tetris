using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace Tetris
{
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
                          { true, true },
                          { true, false },
                          { true, false }
                        },
            new bool[,] {
                          { false, false, false },
                          { true, true, true },
                          { false, false, true }
                        },
            new bool[,] {
                          { false, true },
                          { false, true },
                          { true, true }
                        }
          }
        },


        new Shape
        {
          Color = Color.Yellow,
          Rotations = new List<bool[,]>() // O
          {
            new bool[,] {
              { true, true },
              { true, true }
          }
          }
        },


        new Shape
        {
          Color = Color.Purple,
          Rotations = new List<bool[,]>() // J
          {
            new bool[,] {
                          { false, true, false },
                          { true, true, true },
                        },

            new bool[,] {
                          { true, false },
                          { true, true },
                          { true, false }
                        },
            new bool[,] {
                          { false, false, false },
                          { true, true, true },
                          { false, true, false }
                        },
            new bool[,] {
                          { false, true },
                          { true, true },
                          { false, true }
                        }
          }
        },

        new Shape
        {
          Color = Color.BrightGreen,
          Rotations = new List<bool[,]>() // S
          {
            new bool[,] {
                          { false, true, true },
                          { true, true, false },
                        },

            new bool[,] {
                          { true, false },
                          { true, true },
                          { true, true },
                          { false, false }
                        },
            new bool[,] {
                          { false, true, true },
                          { true, true, false }
                        },
            new bool[,] {
                          { true, false },
                          { true, true },
                          { false, true }
                        }
          }
        },


        new Shape
        {
          Color = Color.Red,
          Rotations = new List<bool[,]>() // Z
          {
            new bool[,] {
                          { true, true, false },
                          { false, true, true },
                        },

            new bool[,] {
                          { false, true },
                          { true, true },
                          { true, false }
                        },
            new bool[,] {
                          { true, true, false },
                          { false, true, true }
                        },
            new bool[,] {
                          { false, true },
                          { true, true },
                          { true, false }
                        }
          }
        },
    };





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
