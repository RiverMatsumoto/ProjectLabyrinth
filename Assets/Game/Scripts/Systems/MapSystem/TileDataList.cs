using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game.Scripts.Systems.MapSystem
{
    [CreateAssetMenu(menuName = "Tiles/TileDataList", fileName = "TileDataList")]
    public class TileDataList : SerializedScriptableObject
    {
        public Dictionary<GameTile, GameTile> tiles;
    }
}