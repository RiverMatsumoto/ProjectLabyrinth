using Game.Scripts.Systems.BattleSystem;
using Game.Scripts.Systems.Commands;
using Game.Scripts.Systems.Data;

namespace Game.Scripts.Systems.SkillCommands
{
    public class HealCommand : ICommand
    {
        private BattleEntity _target;
        private BattleEntity _user;
    
        public HealCommand(BattleEntity target, BattleEntity user)
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
