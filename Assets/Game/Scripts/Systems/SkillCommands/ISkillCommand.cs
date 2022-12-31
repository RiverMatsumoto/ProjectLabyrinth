namespace Game.Scripts.Systems.SkillCommands
{
    /// <summary>
    /// Skill Commands are versatile commands that are expected to be used for
    /// game functionality such as attacks, status effects, map effects, dialogue, etc.
    /// </summary>
    public interface ISkillCommand
    {
        void Execute();
    }
}
