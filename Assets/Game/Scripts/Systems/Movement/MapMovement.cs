using System.Collections;
using DG.Tweening;
using Game.Scripts.Core;
using ProjectLabyrinth.Game.UI.PlayerMenu;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.Movement
{
    public class MapMovement : MonoBehaviour
    {
        [Inject] protected MapSystem.MapSystem mapSystem;

        public Vector2Int position;
        public Vector2Int localForward;
        public Vector2Int localRight;
        public Vector2Int localBack;
        public Vector2Int localLeft;

        public float moveTime = 0.2F;
        public float moveCooldownTime = 0.01F;
        public float moveDistance = 5;
        protected bool isMoving;

        void Start()
        {
            // Initialize everything 
            localForward = new Vector2Int(0, 1);
            localBack = new Vector2Int(0, -1);
            localRight = new Vector2Int(1, 0);
            localLeft = new Vector2Int(-1, 0);
        }

        #region Movement: turning the player

        public virtual void AttemptTurn(Vector3 direction)
        {
            if (!AllowedToMove()) return;

            StartCoroutine(Turn(direction));
        }

        /// <summary>
        /// A coroutine that turns the player a quarter turn on it's right-facing  or left-facing direction.
        /// </summary>
        /// <param name="axis">A Vector3 direction for which direction to turn the player.</param>
        /// <returns>Is a coroutine. Returns a coroutine yield.</returns>
        public virtual IEnumerator Turn(Vector3 axis)
        {
            if (axis == transform.up) TurnToLocalRight();
            else if (axis == -transform.up) TurnToLocalLeft();
            else yield break;

            isMoving = true;
            transform.DOLocalRotate(transform.localRotation.eulerAngles + (axis * 90), moveTime).SetEase(Ease.OutQuad);

            yield return new WaitForSeconds(moveTime + moveCooldownTime);
            isMoving = false;
        }


        /// <summary>
        /// When turning right, converts the current facing direction to match the map's absolute facing directions.
        /// </summary>
        protected void TurnToLocalRight()
        {
            Vector2Int tempF = localForward;
            Vector2Int tempR = localRight;
            Vector2Int tempB = localBack;
            Vector2Int tempL = localLeft;
            localForward = tempR;
            localRight = tempB;
            localBack = tempL;
            localLeft = tempF;
        }

        /// <summary>
        /// When turning left, converts the current facing direction to match the map's absolute facing directions.
        /// </summary>
        protected void TurnToLocalLeft()
        {
            Vector2Int tempF = localForward;
            Vector2Int tempR = localRight;
            Vector2Int tempB = localBack;
            Vector2Int tempL = localLeft;
            localForward = tempL;
            localRight = tempF;
            localBack = tempR;
            localLeft = tempB;
        }

        #endregion

        #region Movement: moving between tiles

        /// <summary>
        /// Attempts to move the entity to the intended position if they are allowed to move.
        /// </summary>
        /// <param name="intendedPosition">The intended Vector3Int position to move to</param>
        public virtual void AttemptMove(Vector3Int intendedPosition)
        {
            if (!AllowedToMove()) return;

            StartCoroutine(Move(intendedPosition));
        }

        /// <summary>
        /// A coroutine that moves the player in the direction they input. Player can move
        /// forward, back, left, and right.
        /// </summary>
        /// <param name="intendedPosition">A Vector3 direction for which direction to move the player.</param>
        /// <returns>Is a coroutine. Returns a coroutine yield.</returns>
        public virtual IEnumerator Move(Vector3Int intendedPosition)
        {
            if (!AllowedToMove()) yield break;

            isMoving = true;
            // LeanTween.move(gameObject, intendedPosition, moveTime).setEaseOutQuad();
            transform.DOMove(MapSystem.MapSystem.V3IntToV3(intendedPosition), moveTime).SetEase(Ease.OutQuad);

            yield return new WaitForSeconds(moveTime + moveCooldownTime);
            isMoving = false;
        }

        /// <summary>
        /// Calculates the intended position to move to by adding a local direction to the current position.
        /// </summary>
        /// <param name="localDir">The local direction to move in</param>
        /// <param name="currentPosition">The position of the gameObject</param>
        /// <returns>A Vector3Int intended position to move to</returns>
        private Vector3Int CalculateIntendedPosition(Vector2Int localDir, Vector3 currentPosition)
        {
            return new Vector3Int(
                (int)(currentPosition.x + localDir.x),
                (int)currentPosition.y,
                (int)(currentPosition.z + localDir.y)
            );
        }

        #endregion

        #region Map related player placement

        /// <summary>
        /// Places the player in a certain location with certain facing direction using the position and direction passed through.
        /// Position should be in the map range and facing direction should be a cardinal direction.
        /// </summary>
        /// <param name="position">The position the player is being placed in</param>
        /// <param name="facingDir"></param>
        public void PlacePlayer(Vector2Int position, Vector2Int facingDir)
        {
            FaceDirection(facingDir);

            Vector3 newPos = new Vector3(); // adjust the physical transform to match the coordinates on the map
            newPos.x = position.x * moveDistance;
            newPos.z = position.y * moveDistance;
            transform.position = newPos;
        }

        protected void FaceDirection(Vector2Int newForward)
        {
            // not gonna lie this is just a magic formula
            localForward = newForward;
            localBack = newForward * -1;
            localLeft.x = localBack.y;
            localLeft.y = localBack.x;
            localRight.x = localForward.y;
            localRight.y = localForward.x;
            Vector3 endRotation = new Vector3(newForward.x, 0, newForward.y);
            Quaternion endDir = transform.localRotation;
            endDir.SetLookRotation(endRotation);
            transform.localRotation = endDir;
        }

        /// <summary>
        /// Do all the checks that this entity is interested in to update the movement permission
        /// </summary>
        protected virtual bool AllowedToMove()
        {
            return !isMoving;
        }

        #endregion


#if UNITY_EDITOR
        [ButtonGroup("Turn")]
        protected void TurnEntityLeft()
        {
            AttemptTurn(-transform.right);
        }

        [ButtonGroup("Turn")]
        protected void TurnEntityRight()
        {
            AttemptTurn(transform.right);
        }

        [PropertySpace]
        [ButtonGroup("Top")]
        protected void MoveForward()
        {
            Vector3Int intendedPosition = CalculateIntendedPosition(localForward, transform.position);
            AttemptMove(intendedPosition);
        }

        [ButtonGroup("LeftRight")]
        protected void MoveLeft()
        {
            Vector3Int intendedPosition = CalculateIntendedPosition(localLeft, transform.position);
            AttemptMove(intendedPosition);
        }

        [ButtonGroup("LeftRight")]
        protected void MoveRight()
        {
            Vector3Int intendedPosition = CalculateIntendedPosition(localRight, transform.position);
            AttemptMove(intendedPosition);
        }

        [ButtonGroup("Down")]
        protected void MoveBack()
        {
            Vector3Int intendedPosition = CalculateIntendedPosition(localBack, transform.position);
            AttemptMove(intendedPosition);
        }
#endif
    }
}