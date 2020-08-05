using UnityEngine;

namespace Entidades.Map
{
    /// <summary>
    /// This object contains all the parametric data for the game map
    /// </summary>
    [CreateAssetMenu(fileName = "GameMapConfiguration", menuName = "Game Configurations/GameMapConfiguration", order = 1)]
    public class GameMapConfiguration : ScriptableObject
    {
        [SerializeField] private Vector2Int _dimensions;

        public Vector2Int Dimensions => _dimensions;
    }
}
