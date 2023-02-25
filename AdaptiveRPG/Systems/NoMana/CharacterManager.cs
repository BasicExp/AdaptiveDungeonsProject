using AdaptiveRPG.Character.Components.Abilities;
using AdaptiveRPG.Character.Components.Equipment;
using AdaptiveRPG.Character.Components.Leveling;

namespace AdaptiveRPG.Systems.NoMana
{
    public class CharacterManager
    {
        public readonly SimpleLevel MaxLevel;

        private SystemManager SystemManager;
        private CharacterSystem CharacterSystem;
        private CharacterClassSystem ClassSystem;
        private LevelingSystem LevelingSystem;


        public CharacterManager(string characterUniqueId, SystemManager systemManager)
        {
            SystemManager = systemManager;
            CharacterSystem = SystemManager.CharacterSystems[characterUniqueId];
            ClassSystem = SystemManager.CharacterClassSystems[CharacterSystem.CharacterClassSystem];
            LevelingSystem = SystemManager.LevelingSystems[CharacterSystem.LevelingSystem];
            MaxLevel = LevelingSystem.Levels.MaxBy(l => l.Level);
            // Validates that Level will return something
            addExpereience(0);
        }

        public string Name { get { return CharacterSystem.Character.Name; } }
        public int Experience { get { return CharacterSystem.Experience; } }

        public int Level { 
            get 
            {
                // Edge cases
                if (this.CharacterSystem.Experience >= MaxLevel.Experience) { return MaxLevel.Level; }

                // Standard case
                SimpleLevel? currentLevel = null;
                foreach (SimpleLevel level in LevelingSystem.Levels)
                {
                    if (this.CharacterSystem.Experience >= level.Experience)
                    {
                        if (currentLevel == null)
                        {
                            currentLevel = level;
                        }
                        else if (currentLevel.Experience < level.Experience)
                        {
                            currentLevel = level;
                        }
                    }
                }

                if (currentLevel == null)
                {
                    throw new NullReferenceException($"No level entry for {this.CharacterSystem.Experience}xp found for {CharacterSystem.Character.Name}");
                }

                return currentLevel.Level;
            }
        }

        public double Attack
        {
            get
            {
                return Math.Floor(
                    CharacterSystem.Stats.Attack + ClassSystem.CharacterClass.Attack + 
                    (Weapon.Attack * WeaponMod) + (Armor.Attack * ArmorMod) + (Hat.Attack * HatMod) + (Shoes.Attack * ShoesMod)
                );
            }
        }

        public double Defense
        {
            get
            {
                return Math.Floor(CharacterSystem.Stats.Defense +  ClassSystem.CharacterClass.Defense +
                    (Weapon.Defense * WeaponMod) + (Armor.Defense * ArmorMod) + (Hat.Defense * HatMod) + (Shoes.Defense * ShoesMod)
                );
            }
        }

        public double HitPoints
        {
            get
            {
                return Math.Floor(CharacterSystem.Stats.HitPoints + ClassSystem.CharacterClass.HitPoints + 
                    (Weapon.HitPoints * WeaponMod) + (Armor.HitPoints * ArmorMod) + (Hat.HitPoints * HatMod) + (Shoes.HitPoints * ShoesMod));
            }
        }

        public double Speed
        {
            get
            {
                return Math.Floor(CharacterSystem.Stats.Speed + ClassSystem.CharacterClass.Speed + 
                    (Weapon.Speed * WeaponMod) + (Armor.Speed * ArmorMod) + (Hat.Speed * HatMod) + (Shoes.Speed * ShoesMod));
            }
        }

        public List<NoManaAbility> AvailableAbilities
        {
            get
            {
                return ClassSystem.CharacterClassAbilities
                    .FindAll(a => a.RequiredLevel <= Level)
                    .ConvertAll(a => SystemManager.Abilities[a.Name]);
            }
        }

        public List<NoManaAbility> AllAbilities
        {
            get
            {
                return ClassSystem.CharacterClassAbilities.ConvertAll(a => SystemManager.Abilities[a.Name]);
            }
        }

        public NoManaWeapon Weapon { get { return SystemManager.Weapons[CharacterSystem.Weapon]; } }
        private double WeaponMod { get { return weaponModifier(Weapon); } }

        public NoManaEquipment Armor { get { return SystemManager.Equipment[CharacterSystem.Armor]; } }
        private double ArmorMod { get { return weightModifier(Armor); } }

        public NoManaEquipment Hat { get { return SystemManager.Equipment[CharacterSystem.Hat]; } }
        private double HatMod { get { return weightModifier(Hat); } }

        public NoManaEquipment Shoes { get { return SystemManager.Equipment[CharacterSystem.Shoes]; } }
        private double ShoesMod { get { return weightModifier(Shoes); } }

        /// <summary>
        /// Add experience to the character
        /// </summary>
        /// <param name="exp">Must be a postive integer</param>
        /// <returns>The number of levels increased from adding the experience</returns>
        /// <exception cref="ArgumentException"></exception>
        public int addExpereience(int exp)
        {
            if (exp < 0)
            {
                throw new ArgumentException($"Cannot add experience for {CharacterSystem.Character.Name}, exp ({exp}) must be a postive value.");
            }

            int currentLevel = Level;
            CharacterSystem.Experience += exp;
            return Level - currentLevel;
        }

        /// <summary>
        /// Change the current character equipment to the passed in piece.
        /// </summary>
        /// <param name="piece"></param>
        /// <exception cref="ArgumentException"></exception>
        public void equip(NoManaEquipment piece)
        {
            if (piece.EquipmentType == EquipmentConst.EQUIPMENT_TYPESET_1.weapon)
            {
                CharacterSystem.Weapon = piece.Name;
            }
            else if (piece.EquipmentType == EquipmentConst.EQUIPMENT_TYPESET_1.hat)
            {
                CharacterSystem.Hat = piece.Name;
            }
            else if (piece.EquipmentType == EquipmentConst.EQUIPMENT_TYPESET_1.shoes)
            {
                CharacterSystem.Shoes = piece.Name;
            }
            else if (piece.EquipmentType == EquipmentConst.EQUIPMENT_TYPESET_1.armor)
            {
                CharacterSystem.Armor = piece.Name;
            }
            else
            {
                throw new ArgumentException($"Equiment piece is of an unknown type ({piece.EquipmentType}) and could not be equiped");
            }
        }

        /// <summary>
        /// Get the modifier for a peice of equipment based on class modifiers for wieght
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        private double weightModifier(NoManaEquipment piece)
        {
            EquipmentWeightModifier? mod = ClassSystem.EquimentWeightModifiers.Find(mod => mod.Weight == piece.EquipmentWeight);
            if (mod != null) 
            { 
                return mod.Modifier;
            }
            return 1.0;
        }

        /// <summary>
        /// Get the modifier for a weapon based on the class modifiers for weight and weapon type
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        private double weaponModifier(NoManaWeapon weapon)
        {
            WeaponTypeModifier? waeponMod = ClassSystem.WeaponTypeModifiers.Find(mod => mod.Type == weapon.EquipmentWeaponSet);
            double weightMod = weightModifier(weapon);
            if (waeponMod != null)
            {
                return waeponMod.Modifier * weightMod;
            }
            return weightMod;
        }

    }
}
