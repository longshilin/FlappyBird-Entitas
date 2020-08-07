using Configuration;
using UnityEngine;

[CreateAssetMenu(menuName = "Configuration/Game Configuration", fileName = "GameConfiguration")]
public class GameConfiguration : ScriptableObject, IGameConfiguration
{
    [Header("Player")] [SerializeField] private float _playerUpwardsVelocity;
    [SerializeField] private float _playerSpawnOrigin;

    [Header("Pipe")] [SerializeField] private float _pipeSpawnInterval;
    [SerializeField] private float _pipeLifetime;
    [SerializeField] private float _pipeOrigin;
    [SerializeField] private float _pipeMovementSpeed;
    [SerializeField] private float _pipeRandomHeightRange;

    public float PlayerUpwardsVelocity => _playerUpwardsVelocity;
    public float PlayerSpawnOrigin => _playerSpawnOrigin;

    public float PipeSpawnInterval => _pipeSpawnInterval;
    public float PipeLifetime => _pipeLifetime;
    public float PipeOrigin => _pipeOrigin;
    public float PipeMovementSpeed => _pipeMovementSpeed;
    public float PipeRandomHeightRange => _pipeRandomHeightRange;
}