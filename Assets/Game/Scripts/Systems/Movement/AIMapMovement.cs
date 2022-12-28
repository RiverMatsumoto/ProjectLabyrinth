using Game.Scripts.Systems.Movement;
using Game.Signals;
using Zenject;

namespace Game.Scripts.Movement
{
    public class AIMapMovement : MapMovement
    {
        [Inject] private SignalBus _signalBus;
        // FOE behavior scriptable object

        public void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            _signalBus.Subscribe<PlayerMovedStartSignal>(OnPlayerMoved);
        }

        private void OnPlayerMoved()
        {
            // calculate behavior from scriptable object
            
        }
    }
}
