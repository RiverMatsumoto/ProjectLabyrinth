using UnityEngine;

namespace Game.Scripts.Signals
{
    public class PlayerMovedEndSignal
    {
        public Vector3Int position;

        public PlayerMovedEndSignal(Vector3Int _position)
        {
            position = _position;
        }
    }
}
