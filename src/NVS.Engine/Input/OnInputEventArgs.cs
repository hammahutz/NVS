using System;

namespace NVS.Engine.Input;

public class OnInputEventArgs : EventArgs
{
    public Aim Aim;
}

public enum Aim
{
    None,
    Keys,
    Mouse,
    GamePad,
    Touch
}