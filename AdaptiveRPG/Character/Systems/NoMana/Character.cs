using AdaptiveRPG.Character.Components.Equipment;
using AdaptiveRPG.Character.Components.Leveling;
using AdaptiveRPG.Character.Components.Stats;
using AdaptiveRPG.Character.Components.CharacterClasses;

namespace AdaptiveRPG.Character.Systems.NoMana
{
    public class Character
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public NoManaStats? Stats { get; set; }
        public NoManaCharacterClass? CharacterClass { get; set; }
        public SimpleLevel? Level { get; set; }
        public NoManaWeapon? Weapon { get; set; }
        public NoManaEquipment? Armor { get; set; }
        public NoManaEquipment? Hat { get;  set; }
        public NoManaEquipment? Shoes { get; set; }
    }
}
