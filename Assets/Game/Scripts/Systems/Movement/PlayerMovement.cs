using System.Collections;
using DG.Tweening;
using Game.Scripts.Core;
using Game.Scripts.Signals;
using Game.Scripts.Systems.MapSystem;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Scripts.Systems.Movement
{
    /// <summary>
    /// Player's responsibilities:
    /// 1. move around the map and update the global actionability state based on that
    /// 2. Update the position of the player on the map
    /// </summary>
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMovement : MapMovement
    {
        public ReactiveProperty<GameTile> tileInFrontOfPlayer;
        public BoolReactiveProperty isFacingInteractable;
        public ReactiveCommand<PlayerMovedEndSignal> moveEnded;
        
        [SerializeField] protected PlayerInput controls;
        [SerializeField] private Vector2 moveInput;
        [SerializeField] private float turnInput;

        [Inject, ShowInInspector] private MapSystem.MapSystem _mapSystem;
        [Inject, ShowInInspector] private GameData _gameData;

        void Start()
        {
            DOTween.Init();
            localForward = new Vector2Int(0, 1);
            localBack = new Vector2Int(0, -1);
            localRight = new Vector2Int(1, 0);
            localLeft = new Vector2Int(-1, 0);
            moveInput = new Vector2();
            turnInput = 0;
            _gameData.EnableMovement();
            _mapSystem.RegisterEntity(this);

            UnityEngine.Debug.Log(SceneManager.GetActiveScene().name);
            if (SceneManager.GetActiveScene().name != "Labyrinth")
                _gameData.DisableMovement();
        }

        private void Awake()
        {
            moveEnded = new ReactiveCommand<PlayerMovedEndSignal>();
        }

        private void Update()
        {
            if (!AllowedToMove()) return;
            
            // read input, convert to intended movement, attempt to move
            moveInput = controls.actions["Movement"].ReadValue<Vector2>();
            if (moveInput != Vector2.zero)
            {
                Vector3Int intendedPosition = CalculateIntendedPosition(moveInput);
                AttemptMove(intendedPosition);
            }
            turnInput = controls.actions["Turn"].ReadValue<float>();
            Vector3 intendedTurnDirection = CalculateTurnDirection(turnInput);
            AttemptTurn(intendedTurnDirection);
        }

        /// <summary>
        /// Checks whether the player is allowed to move or not.
        /// </summary>
        protected override bool AllowedToMove() => _gameData.permitMovingPlayer;

        #region Movement
        /// <summary>
        /// Calculates a direction to turn in given an input.
        /// </summary>
        /// <param name="input">The user controls input</param>
        /// <returns>A Vector3 intended direction to turn towards.</returns>
        private Vector3 CalculateTurnDirection(float input)
        {
            if (input > 0.5) return transform.up;
            if (input < -0.5f) return -transform.up;
            return Vector3.zero;
        }
        
        /// <summary>
        /// Called in the fixed update loop. Reads the controller input and moves
        /// the player in the direction they press.
        /// </summary>
        /// <param name="direction">The intended direction to turn to.</param>
        public override void AttemptTurn(Vector3 direction)
        {
            StartCoroutine(Turn(direction));
        }
        
        /// <summary>
        /// A coroutine that turns the player a quarter turn on it's right-facing  or left-facing direction.
        /// </summary>
        /// <param name="axis">A Vector3 direction for which direction to turn the player.</param>
        /// <returns>Is a coroutine. Returns a coroutine yield.</returns>
        public override IEnumerator Turn(Vector3 axis)
        {
            if (axis == transform.up) TurnToLocalRight();
            else if (axis == -transform.up) TurnToLocalLeft();
            else yield break;

            // Rotate around the y axis by 90 degrees
            // LeanTween.rotate(gameObject, transform.localRotation.eulerAngles + (axis*90), moveTime).setEaseOutQuad();
            OnTurnStarted();
            transform.DOLocalRotate(transform.localRotation.eulerAngles + (axis * 90), moveTime).SetEase(Ease.OutSine);
            
            yield return new WaitForSeconds(moveTime + moveCooldownTime);
            OnTurnEnded();
        }

        private void OnTurnStarted()
        {
            _gameData.DisableMovement();
        }

        private void OnTurnEnded()
        {
            _gameData.EnableMovement();
            UpdateTileInFrontOfPlayer();
        }


        ///  <summary>
        ///  Uses the already read input values
        ///  and moves the player in the direction they press.
        /// </summary>
        /// <param name="intendedPosition">
        /// The intended position to move to.
        /// </param>
        public override void AttemptMove(Vector3Int intendedPosition)
        {
            if (!AllowedToMove()) return;

            // check if intended move is a valid move and if so, place character one in that direction and coroutine move player
            if (mapSystem.GetTile(intendedPosition).isWalkable)
            {
                StartCoroutine(Move(intendedPosition));
            }
        }
        
        // Add options to move using a direction and magnitude
        /// <summary>
        /// Moves the player to the intended position.
        /// </summary>
        /// <param name="intendedPosition">A Vector3Int position for where to move the player.</param>
        /// <returns>Is a coroutine. Returns a coroutine yield.</returns>
        public override IEnumerator Move(Vector3Int intendedPosition)
        {
            if (!AllowedToMove()) yield break;

            transform.DOMove(MapSystem.MapSystem.V3IntToV3(intendedPosition), moveTime).SetEase(Ease.OutSine);
            
            OnMoveStarted();
            yield return new WaitForSeconds(moveTime + moveCooldownTime);
            OnMoveEnded();
        }

        public void MoveStatic(Vector3Int intendedPosition)
        {
            transform.position = intendedPosition;
            OnMoveEnded();
        }

        private void OnMoveStarted()
        {
            _gameData.DisableMovement();
        }

        private void OnMoveEnded()
        {
            moveEnded.Execute(new PlayerMovedEndSignal(MapSystem.MapSystem.V3ToV3Int(transform.position)));
            UpdateTileInFrontOfPlayer();
            isFacingInteractable.Value = tileInFrontOfPlayer.Value.isInteractable;
            _gameData.EnableMovement();
        }

        private void UpdateTileInFrontOfPlayer() => tileInFrontOfPlayer.Value = GetTileInFrontOfPlayer();
        
        public GameTile GetTileInFrontOfPlayer()
        {
            Vector3Int positionInFrontOfPlayer = AddLocalDirToCurrPos(localForward, transform.position);
            return mapSystem.GetTile(positionInFrontOfPlayer);
        }
        
        /// <summary>
        /// Calculates the final movement position given a vector2 user input.
        /// </summary>
        /// <param name="userInput">The movement user input from controls</param>
        /// <returns>A final Vector3Int position to move to in world space</returns>
        private Vector3Int CalculateIntendedPosition(Vector2 userInput)
        {
            // add corresponding input and localDirection to the current transform.position
            if (userInput.y > 0.5) return AddLocalDirToCurrPos(localForward, transform.position);
            if (userInput.y < -0.5) return AddLocalDirToCurrPos(localBack, transform.position);
            if (userInput.x > 0.5) return AddLocalDirToCurrPos(localRight, transform.position);
            if (userInput.x < -0.5) return AddLocalDirToCurrPos(localLeft, transform.position);
            return Vector3Int.zero;
        }
        
        /// <summary>
        /// Adds the local direction to current position to get a final position.
        /// </summary>
        /// <param name="localDir">The local direction to move in</param>
        /// <param name="currentPositon">Current position of the gameObject</param>
        /// <returns>Vector3Int final position for where to move to</returns>
        private Vector3Int AddLocalDirToCurrPos(Vector2Int localDir, Vector3 currentPosition)
        {
            return new Vector3Int(
                Mathf.RoundToInt(currentPosition.x + localDir.x),
                (int)currentPosition.y,
                Mathf.RoundToInt(currentPosition.z + localDir.y)
            );
        }
        private Vector3Int AddLocalDirToCurrPos(Vector2Int localDir, Vector3Int currentPosition)
        {
            return new Vector3Int(
                currentPosition.x + localDir.x,
                currentPosition.y,
                currentPosition.z + localDir.y
            );
        }
        #endregion
    }
}
