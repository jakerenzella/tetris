using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace Tetris
{
  public class Game
  {
    private Timer timer;
    private PieceType[,] grid;
    private Tetromino _tetromino;
    private Tetromino _shadowTetromino;
    private int ticks;
    private int inputDelay;

    private InputManager inputManager;
    private delegate void Operation(Tetromino tetromino);

    private void initialiseGrid()
    {
      for (int x = 0; x < GameConstants.Columns; x++)
      {
        for (int y = 0; y < GameConstants.Rows; y++)
        {
          grid[x, y] = PieceType.Empty;
        }
      }
    }

    public Game()
    {
      grid = new PieceType[GameConstants.Columns, GameConstants.Rows];
      initialiseGrid();
      _tetromino = new Tetromino();
      _shadowTetromino = (Tetromino)_tetromino.Clone();
      _shadowTetromino.Type = PieceType.Shadow;

      inputManager = new InputManager();

      ticks = inputDelay = 0;
      timer = new Timer("gametime");
      timer.Start();
    }

    private bool isLocationOccupied(int x, int y)
    {
      return (grid[x, y] != PieceType.Empty);
    }

    public void Draw()
    {
      _shadowTetromino.Draw();
      for (int x = 0; x < GameConstants.Columns; x++)
      {
        for (int y = 0; y < GameConstants.Rows; y++)
        {
          if (isLocationOccupied(x, y))
          {
            SplashKit.FillRectangle(Extensions.PieceTypeToColor(grid[x,y]), x * GameConstants.GridWidth, y * GameConstants.GridHeight, GameConstants.GridWidth, GameConstants.GridHeight);
          }
          // else
          // {
            SplashKit.DrawRectangle(Color.Gray, x * GameConstants.GridWidth, y * GameConstants.GridHeight, GameConstants.GridWidth, GameConstants.GridHeight);
          // }
        }
      }
      _tetromino.Draw();
    }

    private bool _checkValidOperation(Operation operation, Tetromino tetromino)
    {
      Tetromino testTetromino = (Tetromino)tetromino.Clone();

      operation(testTetromino);
      if (_isOffScreen(testTetromino))
      {
        return false;
      }
      else if (_blockCollision(testTetromino))
      {
        return false;
      }
      return true;
    }

    private bool doOperation(Operation operation, Tetromino tetromino)
    {
      if (_checkValidOperation(operation, tetromino))
      {
        operation(tetromino);
        return true;
      }
      if (operation == Tetromino.Fall && tetromino == _tetromino)
      {
        _killTetromino();
      }
      return false;
    }

    private bool _isOffScreen(Tetromino tetromino)
    {
      int x = tetromino.X;
      int rightX = x + tetromino.Width - 1;
      int y = tetromino.Y;
      int bottomY = y + tetromino.Height - 1;

      return rightX >= 10 || x < 0 || bottomY >= 20;
    }

    private bool _blockCollision(Tetromino tetromino)
    {
      for (int row = 0; row < tetromino.Width; row++)
      {
        for (int col = 0; col < tetromino.Height; col++)
        {
          if (tetromino.Y > 0 && tetromino.Shape.GetShape[col, row] && isLocationOccupied(row + tetromino.X, col + tetromino.Y))
          {
            return true;
          }
        }
      }
      return false;
    }

    public void _killTetromino()
    {
      for (int row = 0; row < _tetromino.Width; row++)
      {
        for (int col = 0; col < _tetromino.Height; col++)
        {
          if (_tetromino.Shape.GetShape[col, row])
          {
            grid[row + _tetromino.X, col + _tetromino.Y] = _tetromino.Type;
          }
        }
      }
      _tetromino = new Tetromino();
    }

    private void performDelayedUserInput()
    {
      if (inputManager.KeyDown(KeyCode.LeftKey))
      {
        doOperation(Tetromino.MoveLeft, _tetromino);
      }
      if (inputManager.KeyDown(KeyCode.RightKey))
      {
        doOperation(Tetromino.MoveRight, _tetromino);
      }
      if (inputManager.KeyDown(KeyCode.DownKey))
      {
        doOperation(Tetromino.Fall, _tetromino);
      }

    }

    private void performInstantUserInput()
    {
      if (inputManager.KeyTyped(KeyCode.UpKey))
      {
        doOperation(Tetromino.Rotate, _tetromino);
      }
      if (inputManager.KeyTyped(KeyCode.SpaceKey))
      {
        while (doOperation(Tetromino.Fall, _tetromino)) ;
      }
    }

    private void updateShadowTetromino()
    {
      _shadowTetromino = (Tetromino)_tetromino.Clone();
      _shadowTetromino.Type = PieceType.Shadow;
      while (doOperation(Tetromino.Fall, _shadowTetromino)) ;
    }

    private bool rowComplete(int row)
    {
      for (int x = 0; x < GameConstants.Columns; x++)
      {
        if (!isLocationOccupied(x, row))
        {
          return false;
        }
      }
      return true;
    }

    private void deleteRow(int rowToDelete)
    {
      Console.WriteLine($"Deleting Row {rowToDelete}");
      for (int row = rowToDelete; row > 0; row--)
      {
        for (int col = 0; col < GameConstants.Columns; col++)
        {
          grid[col, row] = grid[col, row - 1];
        }
      }

      for (int col = 0; col < GameConstants.Columns; col++)
      {
        grid[col, 0] = PieceType.Empty;
      }
    }

    private void clearLines()
    {
      int numRowsComplete = 0;
      for (int row = GameConstants.Rows - 1; row >= 0; row--)
      {
        if (rowComplete(row))
        {
          deleteRow(row);
          Console.WriteLine($"{row} is now a full Line");
          numRowsComplete++;
        }
      }
    }

    public void Update()
    {
      clearLines();
      updateShadowTetromino();

      performInstantUserInput();
      if ((((int)timer.Ticks) / 100) >= inputDelay)
      {
        performDelayedUserInput();
        inputDelay++;
      }

      if ((((int)timer.Ticks) / 1000) >= ticks)
      {
        doOperation(Tetromino.Fall, _tetromino);
        ticks++;
      }
    }
  }
}