namespace Game.Scripts.Core
{
    public interface ISaveable
    {
        object CaptureState();
        void RestoreState(object state);
    }
}