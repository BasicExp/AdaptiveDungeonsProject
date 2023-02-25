using AdaptiveRPG.Character.Components.Stats;
using AdaptiveRPG.Combat;
using System.Xml.Serialization;
using AdaptiveRPG.Combat.Components.AI;

namespace AdaptiveRPG.Systems.NoMana
{
    public class EnemySystem
    {
        public SimpleEnemy Enemy { get; set; }
        public NoManaStats Stats { get; set; }
        public AIConst.AI_TYPESET_1 AIType { get; set; }

        [XmlArrayItem("Ability")]
        public List<string> Abilities { get; set; }
    }
}
