using System;
using UnityEngine;

public interface IInputHandler
{
    public event Action OnInputHold;
    public event Action OnInputClick;
    void GetInputHold(bool active);
    void GetInputClick(bool active);
}
