using Game.Scripts.Movement;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace Game.Scripts.Systems.MapSystem
{
    [CreateAssetMenu(fileName = "TileData", menuName = "Tiles/TileData")]
    public class GameTile : Tile
    {
        public bool isWalkable;
        public bool blocksMovement;
        public bool isInteractable;
        public bool isLocked;
        public IInteractable interactable;

        public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
        {
            flags = TileFlags.InstantiateGameObjectRuntimeOnly;
            return base.StartUp(position, tilemap, go);
        }
    }
}