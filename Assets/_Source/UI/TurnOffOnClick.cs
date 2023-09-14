using UnityEngine;
using Zenject;

public class TurnOffOnClick : MonoBehaviour
{
    IInputHandler input;
    [Inject]
    private void Construct(IInputHandler input)
    {
        this.input = input;
    }

    private void OnEnable()
    {
        input.OnInputClick += TurnOff;
    }

    private void OnDisable()
    {
        input.OnInputClick -= TurnOff;
    }

    private void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
