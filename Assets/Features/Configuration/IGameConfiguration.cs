using Entitas.CodeGeneration.Attributes;

namespace Configuration
{
    [Configuration, Unique, ComponentName("GameConfiguration")]
    public interface IGameConfiguration
    {
        float PlayerUpwardsVelocity { get; }
        float PlayerSpawnOrigin { get; }

        float PipeSpawnInterval { get; }
        float PipeLifetime { get; }
        float PipeOrigin { get; }
        float PipeMovementSpeed { get; }
        float PipeRandomHeightRange { get; }
    }
}