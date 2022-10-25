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

        public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
        {
            base.GetTileData(position, tilemap, ref tileData);
        }

        public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
        {
            // tilemap.GetTileFlags(position) = TileFlags.None;
            return base.StartUp(position, tilemap, go);
        }

        public struct EnterableDirections
        {
            public bool Top;
            public bool Bottom;
            public bool Left;
            public bool Right;
        }
    }
}