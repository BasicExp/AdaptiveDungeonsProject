using AdaptiveRPG.Character;
using AdaptiveRPG.Character.Components.Abilities;
using AdaptiveRPG.Character.Components.CharacterClasses;
using AdaptiveRPG.Character.Components.Equipment;
using AdaptiveRPG.Character.Components.Leveling;
using AdaptiveRPG.Character.Components.Stats;
using AdaptiveRPG.Systems.NoMana;
using AdaptiveRPG.Systems.Util;

namespace TestGrounds.AdaptiveRPG.NoMana
{
    public class NoManaTestGround
    {
        public static NoManaSystem LoadSampleCharacterSystem(string path)
        {
            SystemLoader<NoManaSystem> loader = new SystemLoader<NoManaSystem>();
            NoManaSystem result = loader.Load(path);
            return result;
        }

        public static void CreateSampleCharacterSystem(string path)
        {
            SystemLoader<NoManaSystem> loader = new SystemLoader<NoManaSystem>();

            // Used for each character
            LevelingSystem lvling1 = new LevelingSystem();
            lvling1.Levels = new List<SimpleLevel>();
            lvling1.Name = "LevelSystem1";

            SimpleLevel lvl1 = new SimpleLevel();
            lvl1.Level = 1;
            lvl1.Experience = 0;
            SimpleLevel lvl2 = new SimpleLevel();
            lvl2.Level = 2;
            lvl2.Experience = 10;
            SimpleLevel lvl3 = new SimpleLevel();
            lvl3.Level = 3;
            lvl3.Experience = 20;


            lvling1.Levels.Add(lvl1);
            lvling1.Levels.Add(lvl2);
            lvling1.Levels.Add(lvl3);

            // Ability stuff
            NoManaAbility ab1 = new NoManaAbility();
            ab1.Name= "ab1";
            ab1.CastTime = 0;
            ab1.Description = "ab1 descrption";
            ab1.EffectType = AbilityConst.EFFECT_TYPE.damage;

            NoManaAbility ab2 = new NoManaAbility();
            ab2.Name = "ab2";
            ab2.CastTime = 0;
            ab2.Description = "ab1 descrption";
            ab2.EffectType = AbilityConst.EFFECT_TYPE.heal;

            CharacterClassAbility ccab1 = new CharacterClassAbility();
            ccab1.RequiredLevel = 10;
            ccab1.Name = "ab1";

            CharacterClassAbility ccab2 = new CharacterClassAbility();
            ccab2.RequiredLevel = 5;
            ccab2.Name = "ab2";

            // Class stuff
            CharacterClassSystem ccs2 = new CharacterClassSystem();
            ccs2.CharacterClass = new NoManaCharacterClass();
            ccs2.CharacterClass.Name = "CharacterClass2";
            ccs2.CharacterClass.Description = "Character Class 2 description";
            ccs2.CharacterClassAbilities = new List<CharacterClassAbility> { ccab1, ccab2 };

            CharacterClassUpgrade ugc1 = new CharacterClassUpgrade();
            ugc1.Name = ccs2.CharacterClass.Name;
            ugc1.RequiredLevel = 10;

            CharacterClassSystem ccs1 = new CharacterClassSystem();
            ccs1.CharacterClass = new NoManaCharacterClass();
            ccs1.CharacterClass.Name = "CharacterClass1";
            ccs1.CharacterClass.Description = "Character Class 1 description";
            ccs1.CharacterClassAbilities = new List<CharacterClassAbility> { ccab1, ccab2 };
            ccs1.ChararcterClassUpgrades = new List<CharacterClassUpgrade> { ugc1 };

            // Characters
            CharacterSystem cs1 = new CharacterSystem();
            cs1.LevelingSystem = lvling1.Name;
            cs1.Character = new SimpleCharacter();
            cs1.Character.Name = "Character1";
            cs1.Character.UniqueId = "MainCharacter1";
            cs1.Character.Description = "Character description here";
            cs1.Stats = new NoManaStats();
            cs1.Stats.HitPoints = 10;
            cs1.Stats.Speed = 10;
            cs1.Stats.Attack = 10;
            cs1.Stats.Defense = 10;
            cs1.CharacterClassSystem = "CharacterClass1";
            cs1.Stats.HitPoints = 10;
            cs1.Stats.Speed = 10;
            cs1.Stats.Attack = 10;
            cs1.Stats.Defense = 10;
            cs1.Level = new SimpleLevel();
            cs1.Level.Level = 1;
            cs1.Level.Experience = 0;
            cs1.Weapon = new NoManaWeapon();
            cs1.Weapon.Name = "Weapon 1";
            cs1.Weapon.Description = "Weapon 1 description";
            cs1.Weapon.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs1.Weapon.EquipmentWeaponSet = EquipmentConst.WEAPONSET_1.sword;
            cs1.Weapon.HitPoints = 10;
            cs1.Weapon.Speed = 10;
            cs1.Weapon.Attack = 10;
            cs1.Weapon.Defense = 10;
            cs1.Armor = new NoManaEquipment();
            cs1.Armor.Name = "Armor 1";
            cs1.Armor.Description = "Arnor 1 description";
            cs1.Armor.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs1.Armor.EquipmentType = EquipmentConst.TYPESET_1.armor;
            cs1.Armor.HitPoints = 10;
            cs1.Armor.Speed = 10;
            cs1.Armor.Attack = 10;
            cs1.Armor.Defense = 10;
            cs1.Hat = new NoManaEquipment();
            cs1.Hat.Name = "Hat 1";
            cs1.Hat.Description = "Hat 1 description";
            cs1.Hat.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs1.Hat.EquipmentType = EquipmentConst.TYPESET_1.hat;
            cs1.Hat.HitPoints = 10;
            cs1.Hat.Speed = 10;
            cs1.Hat.Attack = 10;
            cs1.Hat.Defense = 10;
            cs1.Shoes = new NoManaEquipment();
            cs1.Shoes.Name = "Shoes 1";
            cs1.Shoes.Description = "Shoes 1 description";
            cs1.Shoes.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs1.Shoes.EquipmentType = EquipmentConst.TYPESET_1.shoes;
            cs1.Shoes.HitPoints = 10;
            cs1.Shoes.Speed = 10;
            cs1.Shoes.Attack = 10;


            CharacterSystem cs2 = new CharacterSystem();
            cs2.LevelingSystem = lvling1.Name;
            cs2.Character = new SimpleCharacter();
            cs2.Character.Name = "Character2";
            cs2.Character.UniqueId = "MainCharacter2";
            cs2.Character.Description = "Character description here";
            cs2.Stats = new NoManaStats();
            cs2.Stats.HitPoints = 10;
            cs2.Stats.Speed = 10;
            cs2.Stats.Attack = 10;
            cs2.Stats.Defense = 10;
            cs2.CharacterClassSystem = "CharacterClass1";
            cs2.Stats.HitPoints = 10;
            cs2.Stats.Speed = 10;
            cs2.Stats.Attack = 10;
            cs2.Stats.Defense = 10;
            cs2.Level = new SimpleLevel();
            cs2.Level.Level = 1;
            cs2.Level.Experience = 0;
            cs2.Weapon = new NoManaWeapon();
            cs2.Weapon.Name = "Weapon 1";
            cs2.Weapon.Description = "Weapon 1 description";
            cs2.Weapon.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs2.Weapon.EquipmentWeaponSet = EquipmentConst.WEAPONSET_1.sword;
            cs2.Weapon.HitPoints = 10;
            cs2.Weapon.Speed = 10;
            cs2.Weapon.Attack = 10;
            cs2.Weapon.Defense = 10;
            cs2.Armor = new NoManaEquipment();
            cs2.Armor.Name = "Armor 1";
            cs2.Armor.Description = "Arnor 1 description";
            cs2.Armor.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs2.Armor.EquipmentType = EquipmentConst.TYPESET_1.armor;
            cs2.Armor.HitPoints = 10;
            cs2.Armor.Speed = 10;
            cs2.Armor.Attack = 10;
            cs2.Armor.Defense = 10;
            cs2.Hat = new NoManaEquipment();
            cs2.Hat.Name = "Hat 1";
            cs2.Hat.Description = "Hat 1 description";
            cs2.Hat.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs2.Hat.EquipmentType = EquipmentConst.TYPESET_1.hat;
            cs2.Hat.HitPoints = 10;
            cs2.Hat.Speed = 10;
            cs2.Hat.Attack = 10;
            cs2.Shoes = new NoManaEquipment();
            cs2.Shoes.Name = "Shoes 1";
            cs2.Shoes.Description = "Shoes 1 description";
            cs2.Shoes.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs2.Shoes.EquipmentType = EquipmentConst.TYPESET_1.shoes;
            cs2.Shoes.HitPoints = 10;
            cs2.Shoes.Speed = 10;
            cs2.Shoes.Attack = 10;


            CharacterSystem cs3 = new CharacterSystem();
            cs3.LevelingSystem = lvling1.Name;
            cs3.Character = new SimpleCharacter();
            cs3.Character.Name = "Character3";
            cs3.Character.UniqueId = "MainCharacter3";
            cs3.Character.Description = "Character description here";
            cs3.Stats = new NoManaStats();
            cs3.Stats.HitPoints = 10;
            cs3.Stats.Speed = 10;
            cs3.Stats.Attack = 10;
            cs3.Stats.Defense = 10;
            cs3.CharacterClassSystem = "CharacterClass1";
            cs3.Stats.HitPoints = 10;
            cs3.Stats.Speed = 10;
            cs3.Stats.Attack = 10;
            cs3.Stats.Defense = 10;
            cs3.Level = new SimpleLevel();
            cs3.Level.Level = 1;
            cs3.Level.Experience = 0;
            cs3.Weapon = new NoManaWeapon();
            cs3.Weapon.Name = "Weapon 1";
            cs3.Weapon.Description = "Weapon 1 description";
            cs3.Weapon.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs3.Weapon.EquipmentWeaponSet = EquipmentConst.WEAPONSET_1.sword;
            cs3.Weapon.HitPoints = 10;
            cs3.Weapon.Speed = 10;
            cs3.Weapon.Attack = 10;
            cs3.Weapon.Defense = 10;
            cs3.Armor = new NoManaEquipment();
            cs3.Armor.Name = "Armor 1";
            cs3.Armor.Description = "Arnor 1 description";
            cs3.Armor.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs3.Armor.EquipmentType = EquipmentConst.TYPESET_1.armor;
            cs3.Armor.HitPoints = 10;
            cs3.Armor.Speed = 10;
            cs3.Armor.Attack = 10;
            cs3.Armor.Defense = 10;
            cs3.Hat = new NoManaEquipment();
            cs3.Hat.Name = "Hat 1";
            cs3.Hat.Description = "Hat 1 description";
            cs3.Hat.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs3.Hat.EquipmentType = EquipmentConst.TYPESET_1.hat;
            cs3.Hat.HitPoints = 10;
            cs3.Hat.Speed = 10;
            cs3.Hat.Attack = 10;
            cs3.Shoes = new NoManaEquipment();
            cs3.Shoes.Name = "Shoes 1";
            cs3.Shoes.Description = "Shoes 1 description";
            cs3.Shoes.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs3.Shoes.EquipmentType = EquipmentConst.TYPESET_1.shoes;
            cs3.Shoes.HitPoints = 10;
            cs3.Shoes.Speed = 10;
            cs3.Shoes.Attack = 10;

            NoManaSystem noMana = new NoManaSystem();
            noMana.Abilities = new List<NoManaAbility> { ab1, ab2 };
            noMana.CharacterClassSystems = new List<CharacterClassSystem> { ccs1, ccs2 }; 
            noMana.CharacterSystems = new List<CharacterSystem> { cs1, cs2, cs3 };
            noMana.LevelingSystems = new List<LevelingSystem> { lvling1 };

            loader.Write(path, noMana);


        }
    }
}
