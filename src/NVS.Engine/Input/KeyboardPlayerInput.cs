using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NVS.Engine.Input;

public class KeyboardPlayerInput : PlayerInput
{
    private KeyboardState keyboardState, lastKeyboardState;
    public KeyboardPlayerInput(InputManager inputManager) : base(inputManager) { }

    protected override event EventHandler<OnInputEventArgs> OnInput;

    public override Vector2 GetAimDirection()
    {
        throw new System.NotImplementedException();
    }

    public override Vector2 GetMovementDirection()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        lastKeyboardState = keyboardState;
        keyboardState = Keyboard.GetState();

        if (keyboardState != lastKeyboardState)
        { 
            Aim aim = new[] { Keys.Left, Keys.Right, Keys.Up, Keys.Down }.Any(k => keyboardState.IsKeyDown(k)) ? Aim.Keys : Aim.None;
            OnInput?.Invoke(this, new OnInputEventArgs { Aim = aim });
        }
    }
}