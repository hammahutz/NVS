using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NVS.Engine.Input;

public class MousePlayerInput : PlayerInput
{
    private MouseState _mouseState, _lastMouseState;
    public MousePlayerInput(InputManager inputManager) : base(inputManager)
    {
    }

    protected override event EventHandler<OnInputEventArgs> OnInput;

    public override Vector2 GetAimDirection(Vector2 orgin)
    {
        Vector2 direction = _mouseState.Position.ToVector2() - orgin;
        return direction != Vector2.Zero ? Vector2.Normalize(direction) : Vector2.Zero;
    }

    public override Vector2 GetMovementDirection(Vector2 orgin) => Vector2.Zero;
    public override void UpdateState()
    {
        _lastMouseState = _mouseState;
        _mouseState = Mouse.GetState();

        if (_mouseState != _lastMouseState)
        {
            OnInput?.Invoke(this, new OnInputEventArgs { Aim = Aim.Mouse });
        }
    }
}