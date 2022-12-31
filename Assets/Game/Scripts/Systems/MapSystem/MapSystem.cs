using System;
using System.Collections.Generic;
using Game.Scripts.Movement;
using Game.Scripts.Systems.Movement;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace Game.Scripts.Systems.MapSystem
{
    public class MapSystem : SerializedMonoBehaviour
    {
        private TileDataList tileDataList; 
        public Tilemap tilemap;
        public List<MapMovement> entities;
        

        /// <summary>
        /// Gets the TileBase at a position
        /// </summary>
        /// <param name="position">The position of the map to access</param>
        /// <returns>A TileBase if there is one at the position</returns>
        public GameTile GetTile(Vector3 position)
        {
            Vector3Int tilePosition = tilemap.WorldToCell(position);
            return tilemap.GetTile<GameTile>(tilePosition);
        }

        /// <summary>
        /// Converts vector3 coordinates into map coordinates using the vector3 x and z coordinates.
        /// </summary>
        /// <param name="position">The Vector3 position to convert</param>
        /// <returns>Vector2Int coordinates for the map</returns>
        public static Vector2Int Vector3ToVector2(Vector3 position) => new Vector2Int((int)position.x, (int)position.z);

        /// <summary>
        /// For converting Vector2Int map coordinates to Vector3Int world space
        /// </summary>
        /// <param name="coordinates">Vector2Int map coordinates</param>
        /// <returns>A Vector3Int for world space</returns>
        public static Vector3Int Vector2IntToVector3(Vector2Int coordinates) => new Vector3Int(coordinates.x, 0, coordinates.y);

        /// <summary>Helper method to convert Vector3Int to Vector3</summary>
        public static Vector3 V3IntToV3(Vector3Int v3i) => new Vector3(v3i.x, v3i.y, v3i.z);
        /// <summary>Helper method to convert Vector3 to Vector3Int</summary>
        public static Vector3Int V3ToV3Int(Vector3 v3) => new Vector3Int(Mathf.RoundToInt(v3.x), Mathf.RoundToInt(v3.y), Mathf.RoundToInt(v3.z));

        public void RegisterEntity(MapMovement entity)
        {
            entities.Add(entity);
        }

        public void UnregisterEntity(MapMovement entity)
        {
            entities.Remove(entity);
        }

        public MapMovement TryGetEntity(Vector2Int position)
        {
            foreach (var entity in entities)
                if (entity.position == position) return entity;
            return null;
        }

        [Button]
        public void LogTile(Vector3 position)
        {
            GameTile gameTile = GetTile(position);
            UnityEngine.Debug.Log(tilemap.GetInstantiatedObject(V3ToV3Int(position)));
            UnityEngine.Debug.Log($"Tile type: {gameTile}");
            UnityEngine.Debug.Log($"Tile is wall?: {gameTile.blocksMovement}");
        }

        [Button]
        public void AdjustTileGameobjects()
        {
            GameObject obj = tilemap.GetInstantiatedObject(new Vector3Int(1, 1, 0));
            obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, 0.01f, obj.transform.localPosition.z);
        }
    }
}