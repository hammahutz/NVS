using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NVS.Engine.Input;

public class InputManager
{
    public string CurrentMovementDevice{ get => _activePlayerMovementInput.ToString(); } 
    public string CurrentAimDevice{ get => _activePlayerAimInput.ToString(); } 
    private Dictionary<string, PlayerInput> _playerInputs;
    private PlayerInput _activePlayerMovementInput;
    private PlayerInput _activePlayerAimInput;

    private bool Pointer;

    public InputManager()
    {
        _playerInputs = new Dictionary<string, PlayerInput>()
        {
            { nameof(KeyboardPlayerInput), new KeyboardPlayerInput(this) },
            { nameof(MousePlayerInput), new MousePlayerInput(this) },
            { nameof(GamePadPlayerInput), new GamePadPlayerInput(this) },
            { nameof(TouchPlayerInput), new TouchPlayerInput(this) },
        };

        _activePlayerMovementInput = _playerInputs[nameof(KeyboardPlayerInput)];
        _activePlayerAimInput = _playerInputs[nameof(KeyboardPlayerInput)];
    }

    public void Update()
    {
        UpdateState();
    }

    private void UpdateState() => _playerInputs.ToList().ForEach(pi => pi.Value.UpdateState());
    public void SwitchState(object sender, OnInputEventArgs e)
    {
        switch (e.Aim)
        {
            case Aim.None:
                _activePlayerMovementInput = _playerInputs[nameof(KeyboardPlayerInput)];
                if (_activePlayerAimInput != _playerInputs[nameof(MousePlayerInput)])
                {
                    _activePlayerAimInput = _playerInputs[nameof(KeyboardPlayerInput)];
                }
                break;

            case Aim.Keys:
                _activePlayerMovementInput = _playerInputs[nameof(KeyboardPlayerInput)];
                _activePlayerAimInput = _playerInputs[nameof(KeyboardPlayerInput)];
                break;

            case Aim.Mouse:
                _activePlayerMovementInput = _playerInputs[nameof(KeyboardPlayerInput)];
                _activePlayerAimInput = _playerInputs[nameof(MousePlayerInput)];
                break;

            case Aim.GamePad:
                _activePlayerMovementInput = _playerInputs[nameof(GamePadPlayerInput)];
                _activePlayerAimInput = _playerInputs[nameof(GamePadPlayerInput)];
                break;

            case Aim.Touch:
                _activePlayerMovementInput = _playerInputs[nameof(TouchPlayerInput)];
                _activePlayerAimInput = _playerInputs[nameof(TouchPlayerInput)];
                break;
        }
    }
    public Vector2 GetMovementDirection(Vector2 orgin) => _activePlayerMovementInput.GetMovementDirection(orgin);
    public Vector2 GetAimDirection(Vector2 orgin) => _activePlayerAimInput.GetAimDirection(orgin);
    public Vector2 GetPointer() => Mouse.GetState().Position.ToVector2();

}
