using UnityEngine;

public class StateGame : AGameState
{
    private readonly GameObject startText;
    public StateGame(GameObject startText)
    {
        this.startText = startText;
    }

    public override void Enter()
    {
        startText.SetActive(false);
    }

    public override void Exit()
    {
        startText.SetActive(true);
    }
}
