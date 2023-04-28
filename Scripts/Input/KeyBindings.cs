using System;

[System.Serializable]
public class KeyBindings {
    private KeyBind[] KeyBinds;
    private MouseKeyBind[] MouseKeyBinds;

    public string GetKey(string Func) {
        KeyBind Key = Array.Find(KeyBinds, key => key.Func == Func);

        if (Key != null) {
            return Key.Key;
        } else {
            return null;
        }
    }

    public int GetMouseKey(string Func) {
        MouseKeyBind Key = Array.Find(MouseKeyBinds, key => key.Func == Func);

        if (Key != null) {
            return Key.Key;
        } else {
            return -1;
        }
    }
}