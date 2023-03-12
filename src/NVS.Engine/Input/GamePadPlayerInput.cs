using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NVS.Engine.Input;

public class GamePadPlayerInput : PlayerInput
{
    private GamePadState _gamePadState, _lastgamePadState;
    public GamePadPlayerInput(InputManager inputManager) : base(inputManager){}

    protected override event EventHandler<OnInputEventArgs> OnInput;

    public override Vector2 GetAimDirection(Vector2 orgin) => _gamePadState.ThumbSticks.Right;

    public override Vector2 GetMovementDirection(Vector2 orgin) => _gamePadState.ThumbSticks.Left;

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