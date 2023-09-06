using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameObject text;
    public override void InstallBindings()
    {
        Container
            .Bind<GameStateMachine>()
            .AsSingle();

        Container
            .Bind<StateGame>()
            .AsSingle()
            .WithArguments<GameObject>(text);
    }
}