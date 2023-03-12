using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NVS.Engine.Input;

public abstract class PlayerInput
{
    public PlayerInput(InputManager inputManager) => OnInput += inputManager.SwitchState;
    protected abstract event EventHandler<OnInputEventArgs> OnInput;
    public abstract void UpdateState();
    public abstract Vector2 GetMovementDirection(Vector2 orgin);
    public abstract Vector2 GetAimDirection(Vector2 orgin);
}
