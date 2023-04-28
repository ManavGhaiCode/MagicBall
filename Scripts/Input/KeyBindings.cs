using UnityEngine;
using System;

[System.Serializable]
public class KeyBindings {
    [SerializeField] private KeyBind[] KeyBinds;
    [SerializeField] private MouseKeyBind[] MouseKeyBinds;

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