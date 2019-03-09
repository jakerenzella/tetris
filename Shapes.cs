using System;
using SplashKitSDK;
using System.Collections.Generic;
using System.Linq;

namespace Tetris
{
  public static class Shapes
  {
    public static List<Shape> TetrisFigures = new List<Shape>()
    {
        new Shape
        {
          Type = PieceType.I,
          Rotations = new List<bool[,]>()
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
          Type = PieceType.J,
          Rotations = new List<bool[,]>()
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
          Type = PieceType.O,
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
          Type = PieceType.T,
          Rotations = new List<bool[,]>() // T
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
          Type = PieceType.S,
          Rotations = new List<bool[,]>() // S
          {
            new bool[,] {
                          { false, true, true },
                          { true, true, false },
                        },

            new bool[,] {
                          { true, false },
                          { true, true },
                          { false, true }
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
          Type = PieceType.Z,
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
