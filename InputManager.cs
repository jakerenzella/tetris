using System.Collections.Generic;
using SplashKitSDK;

class InputManager
{
    private Dictionary<int, bool> keyTyped;
    private Dictionary<int, bool> keyDown;
    private Dictionary<int, bool> keyUp;
    
    KeyCallback typedCB;
    KeyCallback downCB;
    KeyCallback upCB;

    public InputManager () {
      keyTyped = new Dictionary<int, bool>();
      keyDown = new Dictionary<int, bool>();
      keyUp = new Dictionary<int, bool>();
      typedCB = keyTypedCallback;
      downCB = keyDownCallback;
      upCB = keyUpCallback;
      SplashKit.RegisterCallbackOnKeyTyped(typedCB);
      SplashKit.RegisterCallbackOnKeyDown(downCB);
      SplashKit.RegisterCallbackOnKeyUp(upCB);
    }

    private void keyTypedCallback(int k) {
      if (!keyTyped.ContainsKey(k)) {
        keyTyped.Add(k, true);
      } else {
        keyTyped[k] = true;
      }
    }
    private void keyDownCallback(int k) {
      if (!keyDown.ContainsKey(k)) {
        keyDown.Add(k, true);
      } else {
        keyDown[k] = true;
      }
    }
    private void keyUpCallback(int k) {
      if (!keyUp.ContainsKey(k)) {
        keyUp.Add(k, true);
      } else {
        keyUp[k] = true;
      }
    }

    public bool KeyTyped(KeyCode k) {
      int key = (int)k;
      if (keyTyped.ContainsKey(key) && keyTyped[key]) {
        keyTyped[key]=false;
        return true;
      }
      return false;
    }
    public bool KeyDown(KeyCode k) {
      int key = (int)k;
      if (keyDown.ContainsKey(key) && keyDown[key]) {
        keyDown[key]=false;
        return true;
      }
      return false;
    }
    public bool KeyUp(KeyCode k) {
      int key = (int)k;
      if (keyUp.ContainsKey(key) && keyUp[key]) {
        keyUp[key]=false;
        return true;
      }
      return false;
    }
}