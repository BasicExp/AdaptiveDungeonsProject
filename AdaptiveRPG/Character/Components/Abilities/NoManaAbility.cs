using System.Xml.Serialization;

namespace AdaptiveRPG.Character.Components.Abilities
{
    public class NoManaAbility
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public AbilityConst.ABILITY_TARGET_TYPESET_1 TargetType { get; set; }
        public AbilityConst.ABILITY_EFFECT_TYPESET_1 EffectType { get; set; }
        public int CastTime { get; set; }
    }
}
