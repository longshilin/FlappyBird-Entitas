using Entitas;
using Entitas.CodeGeneration.Attributes;

/// <summary>
/// Represents the player
/// </summary>
[Game, Unique, ComponentName("Player")]
public class PlayerComponent : IComponent
{
}