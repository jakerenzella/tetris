using System;
using SplashKitSDK;

namespace Tetris
{
  public static class GameConstants
  {
    public const int GridSize = 20;

    private const double columns = 10;
    private const double rows = 20;

    public static double GameWidth = SplashKit.CurrentWindowWidth() / columns;
    public static double GameHeight = SplashKit.CurrentWindowHeight() / rows;

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