using AdaptiveRPG.Character.Components.Abilities;
using AdaptiveRPG.Character.Components.CharacterClasses;

namespace AdaptiveRPG.Systems.NoMana
{
    public class CharacterClassAbility
    {
        public int RequiredLevel { get; set; }
        public string? Ability { get; set; }
    }

    public class CharacterClassSystem
    {
        public NoManaCharacterClass? CharacterClass { get; set; }
        public List<CharacterClassAbility>? ClassAbilities { get; set; }
        public List<string>? UpgradeClasses { get; set; }
    }
}