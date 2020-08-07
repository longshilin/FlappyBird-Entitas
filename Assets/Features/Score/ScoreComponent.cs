using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique, Event(EventTarget.Any)]
public sealed class ScoreComponent : IComponent
{
    public int Value;
}