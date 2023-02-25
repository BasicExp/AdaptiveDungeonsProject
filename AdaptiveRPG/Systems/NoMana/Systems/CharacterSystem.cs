using AdaptiveRPG.Character;
using AdaptiveRPG.Character.Components.Stats;

namespace AdaptiveRPG.Systems.NoMana
{
    public class CharacterSystem
    {
        public string? CharacterClassSystem { get; set; }
        public string? LevelingSystem { get; set; }
        public int Experience { get; set; }

        public SimpleCharacter? Character { get; set; }
        public NoManaStats? Stats { get; set; }
        public string? Weapon { get; set; }
        public string? Armor { get; set; }
        public string? Hat { get; set; }
        public string? Shoes { get; set; }
    }

}
