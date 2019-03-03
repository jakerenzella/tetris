using System;
using SplashKitSDK;

namespace Tetris
{

  public class Game
  {
    private Timer timer;
    private bool[,] grid;
    private Tetromino _tetromino;
    private Tetromino _shadowTetromino;
    private int ticks;
    private int inputDelay;
    private delegate void Operation(Tetromino tetromino);

    public Game()
    {
      grid = new bool[GameConstants.Columns, GameConstants.Rows];
      _tetromino = new Tetromino();
      _shadowTetromino = (Tetromino)_tetromino.Clone();

      ticks = inputDelay = 0;
      timer = new Timer("gametime");
      timer.Start();
    }

    public void Draw()
    {
      for (int x = 0; x < GameConstants.Columns; x++)
      {
        for (int y = 0; y < GameConstants.Rows; y++)
        {
          if (grid[x, y])
          {
            SplashKit.FillRectangle(Color.Gray, x * GameConstants.GridWidth, y * GameConstants.GridHeight, GameConstants.GridWidth, GameConstants.GridHeight);
          }
          else
          {
            SplashKit.DrawRectangle(Color.Gray, x * GameConstants.GridWidth, y * GameConstants.GridHeight, GameConstants.GridWidth, GameConstants.GridHeight);
          }
        }
      }
      _tetromino.Draw();
      _shadowTetromino.Draw();
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

    private bool _doOperation(Operation operation, Tetromino tetromino)
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
          if (tetromino.Shape[col, row] && grid[row + tetromino.X, col + tetromino.Y])
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
          if (_tetromino.Shape[col, row])
          {
            grid[row + _tetromino.X, col + _tetromino.Y] = true;
          }
        }
      }
      _tetromino = new Tetromino();
    }

    private void CheckUserInput()
    {
      if (SplashKit.KeyDown(KeyCode.LeftKey))
      {
        _doOperation(Tetromino.MoveLeft, _tetromino);
      }
      if (SplashKit.KeyDown(KeyCode.RightKey))
      {
        _doOperation(Tetromino.MoveRight, _tetromino);
      }
      if (SplashKit.KeyDown(KeyCode.DownKey))
      {
        _doOperation(Tetromino.Fall, _tetromino);
      }
      if (SplashKit.KeyDown(KeyCode.SpaceKey))
      {
        while (_doOperation(Tetromino.Fall, _tetromino)) ;
      }
    }

    private void _updateShadowTetromino()
    {
      _shadowTetromino = (Tetromino)_tetromino.Clone();
      _shadowTetromino.Color = Color.LightGray;
      while (_doOperation(Tetromino.Fall, _shadowTetromino)) ;
    }

    private bool _rowComplete(int row)
    {
      for (int x = 0; x < GameConstants.Columns; x++)
      {
        if (!grid[x, row])
        {
          return false;
        }
      }
      return true;
    }

    private void _deleteRow(int rowToDelete)
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
        grid[col, 0] = false;
      }
    }

    private void _clearLines()
    {
      int numRowsComplete = 0;
      for (int row = GameConstants.Rows - 1; row >= 0; row--)
      {
        if (_rowComplete(row))
        {
          _deleteRow(row);
          Console.WriteLine($"{row} is now a full Line");
          numRowsComplete++;
        }
      }
    }

    public void Update()
    {
      _clearLines();
      _updateShadowTetromino();
      if ((((int)timer.Ticks) / 100) >= inputDelay)
      {
        CheckUserInput();
        inputDelay++;
      }

      if ((((int)timer.Ticks) / 1000) >= ticks)
      {
        _doOperation(Tetromino.Fall, _tetromino);
        ticks++;
      }
    }
  }
}