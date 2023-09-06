using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
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