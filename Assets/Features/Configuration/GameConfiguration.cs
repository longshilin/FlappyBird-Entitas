using Configuration;
using UnityEngine;

[CreateAssetMenu(menuName = "Configuration/Game Configuration", fileName = "GameConfiguration")]
public class GameConfiguration : ScriptableObject, IGameConfiguration
{
    [SerializeField] private float _playerUpwardsVelocity; 
    [SerializeField] private float _pipeSpawnInterval;
    [SerializeField] private float _pipeLifetime;
    [SerializeField] private float _pipeOrigin;
    [SerializeField] private float _pipeMovementSpeed;

    public float PlayerUpwardsVelocity => _playerUpwardsVelocity;
    public float PipeSpawnInterval => _pipeSpawnInterval;

    public float PipeLifetime => _pipeLifetime;

    public float PipeOrigin => _pipeOrigin;
    public float PipeMovementSpeed => _pipeMovementSpeed;
}