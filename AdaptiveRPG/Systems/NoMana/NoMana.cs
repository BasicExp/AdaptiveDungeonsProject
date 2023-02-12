using AdaptiveRPG.Character.Components.Abilities;

namespace AdaptiveRPG.Systems.NoMana
{
    public class NoManaSystem
    {
        public List<NoManaAbility> Abilities { get; set; }
        public List<CharacterClassSystem> CharacterClassSystems { get; set; }
        public List<CharacterSystem> CharacterSystems { get; set; }
    }
}
