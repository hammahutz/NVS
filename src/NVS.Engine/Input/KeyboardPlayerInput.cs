using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NVS.Engine.Input;

public class KeyboardPlayerInput : PlayerInput
{
    private KeyboardState _keyboardState, _lastKeyboardState;
    public KeyboardPlayerInput(InputManager inputManager) : base(inputManager) { }

    protected override event EventHandler<OnInputEventArgs> OnInput;

    public override Vector2 GetAimDirection(Vector2 origin)
    {
        Vector2 direction = new Vector2();

        if (_keyboardState.IsKeyDown(Keys.Right)) direction.X += 1;
        if (_keyboardState.IsKeyDown(Keys.Up)) direction.Y -= 1;
        if (_keyboardState.IsKeyDown(Keys.Left)) direction.X -= 1;
        if (_keyboardState.IsKeyDown(Keys.Down)) direction.Y += 1;

        if(direction != Vector2.Zero)
        {
            direction.Normalize();
        }

        return direction;
    }

    public override Vector2 GetMovementDirection(Vector2 origin)
    {
        Vector2 direction = new Vector2();

        if (_keyboardState.IsKeyDown(Keys.D)) direction.X += 1;
        if (_keyboardState.IsKeyDown(Keys.W)) direction.Y -= 1;
        if (_keyboardState.IsKeyDown(Keys.A)) direction.X -= 1;
        if (_keyboardState.IsKeyDown(Keys.S)) direction.Y += 1;

        if(direction != Vector2.Zero)
        {
            direction.Normalize();
        }

        return direction;
    }

    public override void UpdateState()
    {
        _lastKeyboardState = _keyboardState;
        _keyboardState = Keyboard.GetState();

        if (_keyboardState != _lastKeyboardState)
        { 
            Aim aim = new[] { Keys.Left, Keys.Right, Keys.Up, Keys.Down }.Any(k => _keyboardState.IsKeyDown(k)) ? Aim.Keys : Aim.None;
            OnInput?.Invoke(this, new OnInputEventArgs { Aim = aim });
        }
    }
}