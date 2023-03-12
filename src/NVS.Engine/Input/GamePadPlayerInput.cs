using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NVS.Engine.Input;

public class GamePadPlayerInput : PlayerInput
{
    private GamePadState _gamePadState, _lastgamePadState;
    public GamePadPlayerInput(InputManager inputManager) : base(inputManager){}

    protected override event EventHandler<OnInputEventArgs> OnInput;

    public override Vector2 GetAimDirection()
    {
        throw new NotImplementedException();
    }

    public override Vector2 GetMovementDirection()
    {
        throw new NotImplementedException();
    }

    public override void UpdateState()
    {
        _lastgamePadState = _gamePadState;
        _gamePadState = GamePad.GetState(PlayerIndex.One);

        if (_gamePadState != _lastgamePadState)
        {
            OnInput?.Invoke(this, new OnInputEventArgs { Aim = Aim.GamePad });
        }
    }
}