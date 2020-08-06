using UnityEngine;

namespace GeometryTowers.Configuration
{
    /// <summary>
    /// Game map configuration data
    /// </summary>
    [CreateAssetMenu(menuName = "Configurations/GameMapConfiguration")]
    public class GameMapConfiguration : ScriptableObject, IGameMapConfiguration
    {
        [SerializeField] private Vector2Int _dimensions;

        public Vector2Int Dimensions => _dimensions;
    }
}