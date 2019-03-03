using System;
using SplashKitSDK;

namespace Tetris
{
  public static class GameConstants
  {
    public const int Columns = 10;
    public const int Rows = 20;

    public static double GridWidth = SplashKit.CurrentWindowWidth() / Columns;
    public static double GridHeight = SplashKit.CurrentWindowHeight() / Rows;

  }

  public class Program
  {
    public static void Main()
    {
      Window w = new Window("Tetris!", 400, 800);
      Game game = new Game();

      while (!w.CloseRequested)
      {
        game.Update();

        w.Clear(Color.White);
        game.Draw();

        SplashKit.RefreshScreen(60);
        SplashKit.ProcessEvents();
      }
    }
  }
}