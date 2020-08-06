using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Event(EventTarget.Self)]
public sealed class VelocityComponent : IComponent
{
    public Vector3 Value;
}