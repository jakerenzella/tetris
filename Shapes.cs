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
          Blocks = new bool[,] {
            {false,false,false,false},
            {true,true,true,true},
            {false,false,false,false},
            {false,false,false,false}
          },
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
          Blocks = new bool[,] { // J
            { true, false, false },
            { true, true, true },
            { false, false, false },
          },
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
          Blocks =
            new bool[,] { // O
              { true, true },
              { true, true }
            },
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
          Blocks = new bool[,] { // T
            {false,true,false},
            {true,true,true},
            {false,false,false},
          },
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
          Color = Color.BrightGreen,
          Blocks = new bool[,] { // S
            { false, true, true },
            { true, true, false },
            { false, false, false },
          },
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
          Color = Color.Red,
          Blocks = new bool[,] { // Z
            { true, true, false },
            { false, true, true },
            { false, false, false },
          },
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
