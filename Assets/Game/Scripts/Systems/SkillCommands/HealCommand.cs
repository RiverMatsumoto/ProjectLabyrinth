using Game.Scripts.Systems.BattleSystem;

namespace Game.Scripts.Systems.SkillCommands
{
    public class HealCommand : ISkillCommand
    {
        private IBattleEntity _target;
        private IBattleEntity _user;
    
        public HealCommand(IBattleEntity target, IBattleEntity user)
        {
            _target = target;
            _user = user;
        }
    
        public void Execute()
        {
            // calculate damage
            // send the command to the target
        }
    }
}
