using Entidades.Map;
using UnityEngine;
using Zenject;

/// <summary>
/// Installer for <see cref="GameMapConfiguration"/> dependencies.
/// </summary>
[CreateAssetMenu(fileName = "GameMapConfigurationInstaller", menuName = "Installers/GameMapConfigurationInstaller")]
public class GameMapConfigurationInstaller : ScriptableObjectInstaller<GameMapConfigurationInstaller>
{
    [SerializeField] private GameMapConfiguration _configuration;

    public override void InstallBindings()
    {
        Container.Bind<GameMapConfiguration>().FromInstance(_configuration).AsSingle();
    }
}