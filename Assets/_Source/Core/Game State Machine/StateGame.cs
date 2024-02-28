using UnityEngine;
using VContainer;

public class StateGame : AGameState
{
    APlayer player;
    ARigidbodyLauncher enemyLauncher;
    ARigidbodyLauncher coinLauncher;
    public StateGame
        (APlayer player, 
        [Inject(Id = InjectIdData.ENEMY_LAUNCHER)] ARigidbodyLauncher enemyLauncher, 
        [Inject(Id = InjectIdData.COIN_LAUNCHER)] ARigidbodyLauncher coinLauncher)
    {
        this.player = player;
        this.enemyLauncher = enemyLauncher;
        this.coinLauncher = coinLauncher;
    }

    public override void Enter()
    {
        player.Activate();
        enemyLauncher.StartLaunch();
        coinLauncher.StartLaunch();
    }
}
