using UnityEngine;

public class StatePause : AGameState
{
    public override void Enter()
    {
        Time.timeScale = 0.000001f;
    }

    public override void Exit()
    {
        Time.timeScale = 1;
    }
}
