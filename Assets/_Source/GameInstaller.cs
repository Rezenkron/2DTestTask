using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Player player;
    [SerializeField] private ARigidbodyLauncher enemyLauncher;
    [SerializeField] private ARigidbodyLauncher coinLauncher;
    public override void InstallBindings()
    {
        Container
            .Bind<IInputHandler>()
            .To<KeyboardAndMouseInput>()
            .AsSingle()
            .NonLazy();

        Container
            .Bind<Player>()
            .FromInstance(player)
            .AsSingle();

        Container
            .Bind<AGameState>()
            .WithId(InjectIdData.PREPARE_STATE_ID)
            .To<StatePrepare>()
            .AsSingle()
            .NonLazy();

        Container
            .Bind<AGameState>()
            .WithId(InjectIdData.GAME_STATE_ID)
            .To<StateGame>()
            .AsSingle()
            .NonLazy();

        Container
            .Bind<IStateMachine>()
            .To<GameStateMachine<AGameState>>()
            .AsSingle()
            .NonLazy();

        Container
            .Bind<ARigidbodyLauncher>()
            .WithId(InjectIdData.ENEMY_LAUNCHER)
            .FromInstance(enemyLauncher)
            .NonLazy();
        Container
            .Bind<ARigidbodyLauncher>()
            .WithId(InjectIdData.COIN_LAUNCHER)
            .FromInstance(coinLauncher)
            .NonLazy();


    }
}

public static class InjectIdData
{
    public const int PREPARE_STATE_ID = 0;
    public const int GAME_STATE_ID = 1;

    public const int ENEMY_LAUNCHER = 2;
    public const int COIN_LAUNCHER = 3;
}