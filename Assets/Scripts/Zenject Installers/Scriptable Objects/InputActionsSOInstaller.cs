using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

[CreateAssetMenu(menuName = "Installers/Input Actions Installer")]
public class InputActionsSOInstaller : ScriptableObjectInstaller<InputActionsSOInstaller> 
{
    private InputActions _inputActions;

    public override void InstallBindings()
    {
        _inputActions = new();
        _inputActions.Enable();

        Container.Bind<InputActions>()
            .FromInstance(_inputActions)
            .AsSingle();
    }
}
