using AdaptiveRPG.Character;
using AdaptiveRPG.Character.Components.Abilities;
using AdaptiveRPG.Character.Components.CharacterClasses;
using AdaptiveRPG.Character.Components.Equipment;
using AdaptiveRPG.Character.Components.Leveling;
using AdaptiveRPG.Character.Components.Stats;
using AdaptiveRPG.Combat;
using AdaptiveRPG.Systems.Util;
using AdaptiveRPG.Combat.Components.AI;

namespace AdaptiveRPG.Systems.NoMana
{
    /// <summary>
    /// This class seperates the structure of the Character from logic that would result in
    /// the mutation of the values. This is done to help keep serialization comprehensible
    /// as well as to restrict access to character fields after instantiation.
    /// </summary>
    public class SystemManager
    {
        public readonly Dictionary<string, NoManaAbility> Abilities;
        public readonly Dictionary<string, NoManaEquipment> Equipment;
        public readonly Dictionary<string, NoManaWeapon> Weapons;

        public readonly Dictionary<string, EnemySystem> EnemySystems;
        public readonly Dictionary<string, CharacterClassSystem> CharacterClassSystems;
        public readonly Dictionary<string, CharacterSystem> CharacterSystems;
        public readonly Dictionary<string, LevelingSystem> LevelingSystems;

        private NoManaSystem noManaSystem;

        public SystemManager(NoManaSystem noManaSystem)
        {
            this.noManaSystem = noManaSystem;

            // Raw Object Lists
            Abilities = new Dictionary<string, NoManaAbility>();
            Equipment = new Dictionary<string, NoManaEquipment>();
            Weapons = new Dictionary<string, NoManaWeapon>();

            noManaSystem.Abilities.ForEach(a => { Abilities.Add(a.Name, a); });
            noManaSystem.Equipment.ForEach(e => { Equipment.Add(e.Name, e); });
            noManaSystem.Weapons.ForEach(w => { Weapons.Add(w.Name, w); });

            // System Lists
            CharacterClassSystems = new Dictionary<string, CharacterClassSystem>();
            CharacterSystems = new Dictionary<string, CharacterSystem>();
            LevelingSystems = new Dictionary<string, LevelingSystem>();
            EnemySystems = new Dictionary<string, EnemySystem>();

            noManaSystem.CharacterClassSystems.ForEach(ccs => { CharacterClassSystems.Add(ccs.CharacterClass.Name, ccs); });
            noManaSystem.CharacterSystems.ForEach(cs => { CharacterSystems.Add(cs.Character.UniqueId, cs); });
            noManaSystem.LevelingSystems.ForEach(ls => { LevelingSystems.Add(ls.Name, ls); });
            noManaSystem.EnemySystems.ForEach(e => { EnemySystems.Add(e.Enemy.Name, e); });

        }
        
        /// <summary>
        /// Save the current state of the system to an XML file at the passed in path
        /// </summary>
        /// <param name="path"></param>
        public void save(string path)
        {
            SystemLoader<NoManaSystem> loader = new SystemLoader<NoManaSystem>();
            loader.Write(path, noManaSystem);
        }

        /// <summary>
        /// Load a system state from an XML file at the passed in path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static SystemManager LoadFromFile(string path)
        {
            SystemLoader<NoManaSystem> loader = new SystemLoader<NoManaSystem>();
            NoManaSystem result = loader.Load(path);
            return new SystemManager(result);
        }

        /// <summary>
        /// Returns a sample version of the NoMana system that you can use to quickly
        /// interact with.
        /// </summary>
        /// <returns></returns>
        public static NoManaSystem CreateSampleSystem()
        {
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
            ab1.Name = "ab1";
            ab1.CastTime = 0;
            ab1.Description = "ab1 descrption";
            ab1.EffectType = Character.Components.Abilities.AbilityConst.ABILITY_EFFECT_TYPESET_1.damage;

            NoManaAbility ab2 = new NoManaAbility();
            ab2.Name = "ab2";
            ab2.CastTime = 0;
            ab2.Description = "ab1 descrption";
            ab2.EffectType = Character.Components.Abilities.AbilityConst.ABILITY_EFFECT_TYPESET_1.heal;

            CharacterClassAbility ccab1 = new CharacterClassAbility();
            ccab1.RequiredLevel = 10;
            ccab1.Name = "ab1";

            CharacterClassAbility ccab2 = new CharacterClassAbility();
            ccab2.RequiredLevel = 5;
            ccab2.Name = "ab2";

            // Equipment stuff
            NoManaWeapon weapon1 = new NoManaWeapon();
            weapon1.Name = "Weapon 1";
            weapon1.Description = "Weapon 1 description";
            weapon1.EquipmentWeight = Character.Components.Equipment.EquipmentConst.EQUIPMENT_WEIGHTS_1.medium;
            weapon1.EquipmentWeaponSet = Character.Components.Equipment.EquipmentConst.EQUIPMENT_WEAPONSET_1.sword;
            weapon1.HitPoints = 10;
            weapon1.Speed = 10;
            weapon1.Attack = 10;
            weapon1.Defense = 10;
            NoManaWeapon weapon2 = new NoManaWeapon();
            weapon2.Name = "Weapon 2";
            weapon2.Description = "Weapon 2 description";
            weapon2.EquipmentWeight = Character.Components.Equipment.EquipmentConst.EQUIPMENT_WEIGHTS_1.medium;
            weapon2.EquipmentWeaponSet = Character.Components.Equipment.EquipmentConst.EQUIPMENT_WEAPONSET_1.sword;
            weapon2.HitPoints = 11;
            weapon2.Speed = 11;
            weapon2.Attack = 11;
            weapon2.Defense = 11;
            NoManaEquipment armor1 = new NoManaEquipment();
            armor1.Name = "Armor 1";
            armor1.Description = "Arnor 1 description";
            armor1.EquipmentWeight = Character.Components.Equipment.EquipmentConst.EQUIPMENT_WEIGHTS_1.medium;
            armor1.EquipmentType = Character.Components.Equipment.EquipmentConst.EQUIPMENT_TYPESET_1.armor;
            armor1.HitPoints = 10;
            armor1.Speed = 10;
            armor1.Attack = 10;
            armor1.Defense = 10;
            NoManaEquipment hat1 = new NoManaEquipment();
            hat1.Name = "Hat 1";
            hat1.Description = "Hat 1 description";
            hat1.EquipmentWeight = Character.Components.Equipment.EquipmentConst.EQUIPMENT_WEIGHTS_1.medium;
            hat1.EquipmentType = Character.Components.Equipment.EquipmentConst.EQUIPMENT_TYPESET_1.hat;
            hat1.HitPoints = 10;
            hat1.Speed = 10;
            hat1.Attack = 10;
            hat1.Defense = 10;
            NoManaEquipment shoes1 = new NoManaEquipment();
            shoes1.Name = "Shoes 1";
            shoes1.Description = "Shoes 1 description";
            shoes1.EquipmentWeight = Character.Components.Equipment.EquipmentConst.EQUIPMENT_WEIGHTS_1.medium;
            shoes1.EquipmentType = Character.Components.Equipment.EquipmentConst.EQUIPMENT_TYPESET_1.shoes;
            shoes1.HitPoints = 10;
            shoes1.Speed = 10;
            shoes1.Attack = 10;

            // Equipment Mods
            EquipmentWeightModifier equipMod1 = new EquipmentWeightModifier();
            equipMod1.Weight = Character.Components.Equipment.EquipmentConst.EQUIPMENT_WEIGHTS_1.medium;
            equipMod1.Modifier = 1.1;

            WeaponTypeModifier wpMod1 = new WeaponTypeModifier();
            wpMod1.Type = Character.Components.Equipment.EquipmentConst.EQUIPMENT_WEAPONSET_1.sword;
            wpMod1.Modifier = 1.2;

            // Class stuff
            CharacterClassSystem ccs2 = new CharacterClassSystem();
            ccs2.CharacterClass = new NoManaCharacterClass();
            ccs2.CharacterClass.Name = "CharacterClass2";
            ccs2.CharacterClass.Description = "Character Class 2 description";
            ccs2.CharacterClassAbilities = new List<CharacterClassAbility> { ccab1, ccab2 };
            ccs2.EquimentWeightModifiers = new List<EquipmentWeightModifier> { equipMod1 };
            ccs2.WeaponTypeModifiers = new List<WeaponTypeModifier> { wpMod1 };

            CharacterClassUpgrade ugc1 = new CharacterClassUpgrade();
            ugc1.Name = ccs2.CharacterClass.Name;
            ugc1.RequiredLevel = 10;

            CharacterClassSystem ccs1 = new CharacterClassSystem();
            ccs1.CharacterClass = new NoManaCharacterClass();
            ccs1.CharacterClass.Name = "CharacterClass1";
            ccs1.CharacterClass.Description = "Character Class 1 description";
            ccs1.CharacterClassAbilities = new List<CharacterClassAbility> { ccab1, ccab2 };
            ccs1.ChararcterClassUpgrades = new List<CharacterClassUpgrade> { ugc1 };
            ccs1.EquimentWeightModifiers = new List<EquipmentWeightModifier> { equipMod1 };
            ccs1.WeaponTypeModifiers = new List<WeaponTypeModifier> { wpMod1 };

            // Characters
            CharacterSystem cs1 = new CharacterSystem();
            cs1.LevelingSystem = lvling1.Name;
            cs1.Character = new SimpleCharacter();
            cs1.Character.Name = "Character1";
            cs1.Character.UniqueId = "MainCharacter1";
            cs1.Character.Description = "Character description here";
            cs1.Experience = 0;
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
            cs1.Weapon = "Weapon 1";
            cs1.Armor = "Armor 1";
            cs1.Hat = "Hat 1";
            cs1.Shoes = "Shoes 1";

            CharacterSystem cs2 = new CharacterSystem();
            cs2.LevelingSystem = lvling1.Name;
            cs2.Character = new SimpleCharacter();
            cs2.Character.Name = "Character2";
            cs2.Character.UniqueId = "MainCharacter2";
            cs2.Character.Description = "Character description here";
            cs2.Experience = 0;
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
            cs2.Weapon = "Weapon 1";
            cs2.Armor = "Armor 1";
            cs2.Hat = "Hat 1";
            cs2.Shoes = "Shoes 1";

            CharacterSystem cs3 = new CharacterSystem();
            cs3.LevelingSystem = lvling1.Name;
            cs3.Character = new SimpleCharacter();
            cs3.Character.Name = "Character3";
            cs3.Character.UniqueId = "MainCharacter3";
            cs3.Character.Description = "Character description here";
            cs3.Experience = 0;
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
            cs3.Weapon = "Weapon 1";
            cs3.Armor = "Armor 1";
            cs3.Hat = "Hat 1";
            cs3.Shoes = "Shoes 1";

            // Enemies
            EnemySystem enemy1 = new EnemySystem();
            enemy1.AIType = Combat.Components.AI.AIConst.AI_TYPESET_1.random;
            enemy1.Enemy = new SimpleEnemy();
            enemy1.Enemy.Name = "Enemy 1";
            enemy1.Enemy.Description = "Enemy 1 descrition";
            enemy1.Stats = new NoManaStats();
            enemy1.Stats.HitPoints = 5;
            enemy1.Stats.Speed = 5;
            enemy1.Stats.Attack = 5;
            enemy1.Stats.Defense = 5;
            enemy1.Abilities = new List<string> { ab1.Name, ab2.Name };

            EnemySystem enemy2 = new EnemySystem();
            enemy2.AIType = Combat.Components.AI.AIConst.AI_TYPESET_1.grudge;
            enemy2.Enemy = new SimpleEnemy();
            enemy2.Enemy.Name = "Enemy 2";
            enemy2.Enemy.Description = "Enemy 2 descrition";
            enemy2.Stats = new NoManaStats();
            enemy2.Stats.HitPoints = 4;
            enemy2.Stats.Speed = 4;
            enemy2.Stats.Attack = 4;
            enemy2.Stats.Defense = 4;
            enemy2.Abilities = new List<string> { ab1.Name };

            // System Creation
            NoManaSystem noMana = new NoManaSystem();
            noMana.Abilities = new List<NoManaAbility> { ab1, ab2 };
            noMana.Weapons = new List<NoManaWeapon> { weapon1, weapon2 };
            noMana.Equipment = new List<NoManaEquipment> { armor1, hat1, shoes1 };
            noMana.CharacterClassSystems = new List<CharacterClassSystem> { ccs1, ccs2 };
            noMana.CharacterSystems = new List<CharacterSystem> { cs1, cs2, cs3 };
            noMana.LevelingSystems = new List<LevelingSystem> { lvling1 };
            noMana.EnemySystems = new List<EnemySystem> { enemy1, enemy2 };

            return noMana;
        }
    }
}
