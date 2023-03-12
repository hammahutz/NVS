using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace NVS.Engine.Input;

public class TouchPlayerInput : PlayerInput
{
    private TouchCollection _touchCollection, _lastTouchCollection;
    public TouchPlayerInput(InputManager inputManager) : base(inputManager) { }

    protected override event EventHandler<OnInputEventArgs> OnInput;

    public override Vector2 GetAimDirection()
    {
        //TODO implement smartphone controlls
        throw new NotImplementedException();
    }

    public override Vector2 GetMovementDirection()
    {
        throw new NotImplementedException();
    }

    public override void UpdateState()
    {
        _lastTouchCollection = _touchCollection;
        _touchCollection = TouchPanel.GetState();

        if (_touchCollection.Count > 0)
        {
            OnInput?.Invoke(this, new OnInputEventArgs { Aim = Aim.Touch });
        }
    }
}