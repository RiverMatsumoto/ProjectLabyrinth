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
            if (go != null)
            {
                go.transform.position = new Vector3(position.x, 0, position.y);
                go.transform.SetPositionAndRotation(go.transform.position, Quaternion.identity);
            }
            return true;
        }
    }
}