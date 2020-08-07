using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Event(EventTarget.Self)]
public class CollisionComponent : IComponent
{
    public GameObject Value;
}