using System;
using UnityEngine;

public class KeyboardAndMouseInput : IInputHandler
{

    public float GetInput(string axes)
    {
        return Input.GetAxis(axes);
    }
}
