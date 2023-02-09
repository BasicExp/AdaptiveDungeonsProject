using AdaptiveRPG.Character.Components.Equipment;
using AdaptiveRPG.Character.Components.Leveling;
using AdaptiveRPG.Character.Components.Stats;
using AdaptiveRPG.Character.Components.CharacterClasses;

namespace AdaptiveRPG.Character.Systems.NoMana
{
    public class Character
    {
        public readonly NoManaStats stats;
        public readonly NoManaCharacterClass characterClass;
        public readonly NoManaLeveling leveling;
        public NoManaWeapon Weapon { get; set; }
        public NoManaEquipment Armor { get; set; }
        public NoManaEquipment Hat { get;  set; }
        public NoManaEquipment Shoes { get; set; }

        public int Attack
        {
            get
            {
                return stats.Attack + characterClass.Attack + Weapon.Attack + 
                    Armor.Attack + Hat.Attack + Shoes.Attack;
            }
        }

        public int Defense
        {
            get
            {
                return stats.Defense + characterClass.Defense + Weapon.Defense +
                    Armor.Defense + Hat.Defense + Shoes.Defense;
            }
        }
    }
}
