using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Event(EventTarget.Self)]
public class CollisionEnter2DComponent : IComponent
{
    public Collision2D Value;
}