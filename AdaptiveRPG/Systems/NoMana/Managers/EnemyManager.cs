using AdaptiveRPG.Character.Components.Abilities;
using AdaptiveRPG.Combat.Components.AI;

namespace AdaptiveRPG.Systems.NoMana
{
    public class EnemyManager
    {
        private SystemManager SystemManager;
        private EnemySystem EnemySystem;

        public EnemyManager(string enenmyName, SystemManager systemManager) 
        { 
            SystemManager = systemManager;
            EnemySystem = SystemManager.EnemySystems[enenmyName];
        }

        private List<NoManaAbility>? _Abilities;
        public List<NoManaAbility> Abilities { 
            get
            {
                if (_Abilities == null) 
                {  
                    _Abilities = EnemySystem.Abilities.ConvertAll(a => SystemManager.Abilities[a]);
                }
                return _Abilities;
            }    
        }

        public AIConst.AI_TYPESET_1 AIType { get { return EnemySystem.AIType; } }    

    }
}
