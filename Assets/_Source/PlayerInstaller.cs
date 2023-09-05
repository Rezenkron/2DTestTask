using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] Player player;
    public override void InstallBindings()
    {
        Container
            .Bind<IInputHandler>()
            .To<KeyboardAndMouseInput>()
            .AsSingle().NonLazy();
        
        Container
            .Bind<JumpPhysics>()
            .AsSingle().NonLazy();
    }
}