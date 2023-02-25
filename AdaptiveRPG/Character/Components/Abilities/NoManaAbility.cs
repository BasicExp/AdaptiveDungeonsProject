namespace AdaptiveRPG.Character.Components.Abilities
{
    public class NoManaAbility
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public AbilityConst.TARGET_TYPE TargetType { get; set; }
        public AbilityConst.EFFECT_TYPE EffectType { get; set; }
        public int CastTime { get; set; }
    }
}
