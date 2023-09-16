using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private APlayer player;
    [SerializeField] private ARigidbodyLauncher enemyLauncher;
    [SerializeField] private ARigidbodyLauncher coinLauncher;
    public override void InstallBindings()
    {
        BindInputHandler();
        BindPlayer();
        BindStateMachine();
        BindStates();
        BindPools();

    }

    private void BindPlayer()
    {
        Container
            .Bind<APlayer>()
            .FromInstance(player)
            .AsSingle();
    }

    private void BindStateMachine()
    {
        Container
            .Bind<IStateMachine>()
            .To<GameStateMachine<AGameState>>()
            .AsSingle()
            .NonLazy();
    }

    private void BindPools()
    {
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

    private void BindInputHandler()
    {
        Container
            .Bind<IInputHandler>()
            .To<InputHandler>()
            .AsSingle()
            .NonLazy();
    }

    private void BindStates()
    {
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
    }
}

public static class InjectIdData
{
    public const int PREPARE_STATE_ID = 0;
    public const int GAME_STATE_ID = 1;

    public const int ENEMY_LAUNCHER = 2;
    public const int COIN_LAUNCHER = 3;
}