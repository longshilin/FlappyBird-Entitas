using Configuration;
using UnityEngine;

[CreateAssetMenu(menuName = "Configuration/Game Configuration", fileName = "GameConfiguration")]
public class GameConfiguration : ScriptableObject, IGameConfiguration
{
    [SerializeField] float _playerUpwardsVelocity; 
    [SerializeField] float _pipeSpawnInterval;

    public float PlayerUpwardsVelocity => _playerUpwardsVelocity;
    public float PipeSpawnInterval => _pipeSpawnInterval;
}