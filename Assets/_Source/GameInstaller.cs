using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameInstaller : LifetimeScope
{
    [SerializeField] private APlayer player;
    [SerializeField] private ARigidbodyLauncher enemyLauncher;
    [SerializeField] private ARigidbodyLauncher coinLauncher;

    private IContainerBuilder _builder;

    protected override void Configure(IContainerBuilder builder)
    {
        BindInputHandler();
        BindPlayer();
        BindStateMachine();
        BindStates();
        BindPools();

        _builder = builder;

    }

    private void BindPlayer()
    {
        _builder.RegisterInstance(player);
    }

    private void BindStateMachine()
    {
        _builder.Register<IStateMachine, GameStateMachine<AGameState>>(Lifetime.Singleton);
    }

    private void BindPools()
    {
        //Container
        //    .Bind<ARigidbodyLauncher>()
        //    .WithId(InjectIdData.ENEMY_LAUNCHER)
        //    .FromInstance(enemyLauncher)
        //    .NonLazy();
        //Container
        //    .Bind<ARigidbodyLauncher>()
        //    .WithId(InjectIdData.COIN_LAUNCHER)
        //    .FromInstance(coinLauncher)
        //    .NonLazy();
    }

    private void BindInputHandler()
    {
        _builder.Register<IInputHandler, InputHandler>(Lifetime.Singleton);
    }

    private void BindStates()
    {
        //Container
        //    .Bind<AGameState>()
        //    .WithId(InjectIdData.PREPARE_STATE_ID)
        //    .To<StatePrepare>()
        //    .AsSingle()
        //    .NonLazy();

        //Container
        //    .Bind<AGameState>()
        //    .WithId(InjectIdData.GAME_STATE_ID)
        //    .To<StateGame>()
        //    .AsSingle()
        //    .NonLazy();

        //----------------------
        //_builder.Register<AGameState>(Lifetime.Scoped).WithParameter<StatePrepare>(new StatePrepare);
        //в доках было написано что-то вроде этого но я не разобрался( по другому не придумал как. Зенжект лучше
        //----------------------
    }
}

public static class InjectIdData
{
    public const int PREPARE_STATE_ID = 0;
    public const int GAME_STATE_ID = 1;

    public const int ENEMY_LAUNCHER = 2;
    public const int COIN_LAUNCHER = 3;
}