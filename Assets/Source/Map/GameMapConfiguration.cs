using System;
using UnityEngine;

namespace Entidades.Map
{
    /// <summary>
    /// Class containing all the data related to the
    /// game map parameters
    /// </summary>
    [Serializable]
    public class GameMapConfiguration
    {
        [SerializeField] private Vector2Int _dimensions;

        public Vector2Int Dimensions => _dimensions;
    }
}
