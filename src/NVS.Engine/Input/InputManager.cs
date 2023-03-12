using System;
using System.Collections.Generic;
using System.Linq;

namespace NVS.Engine.Input;

public class InputManager
{
    public Dictionary<string, PlayerInput> PlayerInputs;
    public PlayerInput ActivePlayerMovementInput;
    public PlayerInput ActivePlayerAimInput;

    public InputManager()
    {
        PlayerInputs = new Dictionary<string, PlayerInput>()
        {
            { nameof(KeyboardPlayerInput), new KeyboardPlayerInput(this) },
            { nameof(MousePlayerInput), new MousePlayerInput(this) },
            { nameof(GamePadPlayerInput), new GamePadPlayerInput(this) },
            { nameof(TouchPlayerInput), new TouchPlayerInput(this) },

        };

        ActivePlayerMovementInput = PlayerInputs[nameof(KeyboardPlayerInput)];
        ActivePlayerAimInput = PlayerInputs[nameof(KeyboardPlayerInput)];
    }

    public void Update()
    {
        UpdateState();
    }

    private void UpdateState() => PlayerInputs.ToList().ForEach(pi => pi.Value.UpdateState());
    public void SwitchState(object sender, OnInputEventArgs e)
    {
        Console.WriteLine($"Key pressed\nSender: {sender}\nAim : {e.Aim}\n");
        switch (e.Aim)
        {
            case Aim.None:
                ActivePlayerMovementInput = PlayerInputs[nameof(KeyboardPlayerInput)];
                if (ActivePlayerAimInput != PlayerInputs[nameof(MousePlayerInput)])
                {
                    ActivePlayerAimInput = PlayerInputs[nameof(KeyboardPlayerInput)];
                }
                break;

            case Aim.Keys:
                ActivePlayerMovementInput = PlayerInputs[nameof(KeyboardPlayerInput)];
                ActivePlayerAimInput = PlayerInputs[nameof(KeyboardPlayerInput)];
                break;

            case Aim.Mouse:
                ActivePlayerMovementInput = PlayerInputs[nameof(KeyboardPlayerInput)];
                ActivePlayerAimInput = PlayerInputs[nameof(MousePlayerInput)];
                break;

            case Aim.GamePad:
                ActivePlayerMovementInput = PlayerInputs[nameof(GamePadPlayerInput)];
                ActivePlayerAimInput = PlayerInputs[nameof(GamePadPlayerInput)];
                break;

            case Aim.Touch:
                ActivePlayerMovementInput = PlayerInputs[nameof(TouchPlayerInput)];
                ActivePlayerAimInput = PlayerInputs[nameof(TouchPlayerInput)];
                break;
        }

        Console.WriteLine($"Dir: {ActivePlayerMovementInput}\nAim: {ActivePlayerAimInput}");
    }
    public virtual void GetMovementDirection() => ActivePlayerMovementInput.GetMovementDirection();
    public virtual void GetAimDirection() => ActivePlayerAimInput.GetAimDirection();
}
