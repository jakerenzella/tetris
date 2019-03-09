// Piece Generator following the Tetris Random Generator standard: https://tetris.fandom.com/wiki/Random_Generator

using System;
using System.Collections.Generic;

namespace Tetris
{
  public static class PieceGenerator
  {

    private static List<Shape> bagOfPieces;
    private static int piecesTaken;

    private static void fillBag()
    {
      bagOfPieces = Shapes.TetrisFigures.Clone();
      bagOfPieces.Shuffle();
      piecesTaken = 0;
    }

    static PieceGenerator()
    {
      fillBag();
    }

    public static Shape GetNextShape()
    {
      if (piecesTaken == bagOfPieces.Count)
      {
        fillBag();
        piecesTaken = 0;
      }

      Shape s = bagOfPieces[piecesTaken];
      piecesTaken++;

      return s;
    }

  }
}