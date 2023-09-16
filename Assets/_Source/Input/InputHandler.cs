using System;
using UnityEngine.InputSystem;

public class InputHandler : IInputHandler
{
    GameControls gameControls;

    public event Action<bool> OnInputHold;
    public event Action OnInputClick;

    public InputHandler()
    {
        gameControls = new GameControls();
        gameControls.Enable();
    }

    public void GetInputHold(bool active)
    {
        if(active)
        {
            ListenJumpHold();
        }
        else StopListenJumpHold();
    }
    public void GetInputClick(bool active)
    {
        if (active)
        {
            ListenJumpClick();
        }
        else StopListenJumpClick();
    }

    private void ListenJumpHold()
    {
        gameControls.Main.Jump.started += OnInputHoldStarted;
        gameControls.Main.Jump.canceled += OnInputHoldCanceled;
    }

    private void ListenJumpClick()
    {
        gameControls.Main.Jump.performed += OnInputClickPerformed;
    }

    private void StopListenJumpHold()
    {
        gameControls.Main.Jump.started -= OnInputHoldStarted;
        gameControls.Main.Jump.canceled -= OnInputHoldCanceled;
    }

    private void StopListenJumpClick()
    {
        gameControls.Main.Jump.performed -= OnInputClickPerformed;
    }

    private void OnInputHoldStarted(InputAction.CallbackContext context)
    {
        OnInputHold?.Invoke(true);
    }
    private void OnInputHoldCanceled(InputAction.CallbackContext context)
    {
        OnInputHold?.Invoke(false);
    }

    private void OnInputClickPerformed(InputAction.CallbackContext context)
    {
        OnInputClick?.Invoke();
    }

}
