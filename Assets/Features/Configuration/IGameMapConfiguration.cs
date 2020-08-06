using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace GeometryTowers.Configuration
{
    [Configuration, Unique, ComponentName("GameMapConfiguration")]
    public interface IGameMapConfiguration
    {
        Vector2Int Dimensions { get; }
    }
}