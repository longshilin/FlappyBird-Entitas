using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Event(EventTarget.Self)]
public class Trigger2DComponent : IComponent
{
    public Collider2D Value;
}