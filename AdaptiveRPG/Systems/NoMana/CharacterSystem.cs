using AdaptiveRPG.Character;
using AdaptiveRPG.Character.Components.Equipment;
using AdaptiveRPG.Character.Components.Leveling;
using AdaptiveRPG.Character.Components.Stats;
using System.Xml.Serialization;

namespace AdaptiveRPG.Systems.NoMana
{
    public class CharacterSystem
    {
        public string? CharacterClassSystem { get; set; }
        public string? LevelingSystem { get; set; }

        public SimpleCharacter? Character { get; set; }
        public NoManaStats? Stats { get; set; }
        public SimpleLevel? Level { get; set; }
        public NoManaWeapon? Weapon { get; set; }
        public NoManaEquipment? Armor { get; set; }
        public NoManaEquipment? Hat { get; set; }
        public NoManaEquipment? Shoes { get; set; }
    }

}
