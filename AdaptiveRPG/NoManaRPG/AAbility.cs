namespace AdaptiveRPG.NoManaRPG
{
    public abstract class AAbility
    {
        public string Name { get; private set; }
        public string TargetType { get; private set; }
        public string EffectType { get; private set; }

        public AAbility(string name, string targetType, string effectType)
        {
            Name = name;
            TargetType = targetType;
            EffectType = effectType;
        }

        public abstract void resolve(Character caster, Character target);
    }
}