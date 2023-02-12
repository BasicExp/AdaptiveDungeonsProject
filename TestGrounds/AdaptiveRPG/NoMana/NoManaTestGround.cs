using AdaptiveRPG.Character.Components.CharacterClasses;
using AdaptiveRPG.Character.Components.Equipment;
using AdaptiveRPG.Character.Components.Leveling;
using AdaptiveRPG.Character.Components.Stats;
using AdaptiveRPG.Character.Systems.NoMana;
using AdaptiveRPG.Systems.Util;

namespace TestGrounds.AdaptiveRPG.NoMana
{
    public class NoManaTestGround
    {
        public static void LoadSampleCharacterSystem(string path)
        {
            SystemLoader<List<CharacterSystem>> loader = new SystemLoader<List<CharacterSystem>>();
            List<CharacterSystem> result = loader.Load(path);
            Console.Write(result);
        }

        public static void CreateSampleCharacterSystem(string path)
        {
            SystemLoader<List<CharacterSystem>> loader = new SystemLoader<List<CharacterSystem>>();

            // Used for each character
            SimpleLeveling lvling1 = new SimpleLeveling();
            lvling1.Levels = new List<SimpleLevel>();

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

            // Characters
            CharacterSystem cs1 = new CharacterSystem();
            cs1.Leveling = lvling1;
            cs1.Character = new Character();
            cs1.Character.Name = "Character1";
            cs1.Character.Description = "Character description here";
            cs1.Character.Stats = new NoManaStats();
            cs1.Character.Stats.HitPoints = 10;
            cs1.Character.Stats.Speed = 10;
            cs1.Character.Stats.Attack = 10;
            cs1.Character.Stats.Defense = 10;
            cs1.Character.CharacterClass = new NoManaCharacterClass();
            cs1.Character.CharacterClass.Name = "Chararcter Class 1";
            cs1.Character.CharacterClass.Description = "Character Class 1 description";
            cs1.Character.Stats.HitPoints = 10;
            cs1.Character.Stats.Speed = 10;
            cs1.Character.Stats.Attack = 10;
            cs1.Character.Stats.Defense = 10;
            cs1.Character.Level = new SimpleLevel();
            cs1.Character.Level.Level = 1;
            cs1.Character.Level.Experience = 0;
            cs1.Character.Weapon = new NoManaWeapon();
            cs1.Character.Weapon.Name = "Weapon 1";
            cs1.Character.Weapon.Description = "Weapon 1 description";
            cs1.Character.Weapon.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs1.Character.Weapon.EquipmentWeaponSet = EquipmentConst.WEAPONSET_1.sword;
            cs1.Character.Weapon.HitPoints = 10;
            cs1.Character.Weapon.Speed = 10;
            cs1.Character.Weapon.Attack = 10;
            cs1.Character.Weapon.Defense = 10;
            cs1.Character.Armor = new NoManaEquipment();
            cs1.Character.Armor.Name = "Armor 1";
            cs1.Character.Armor.Description = "Arnor 1 description";
            cs1.Character.Armor.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs1.Character.Armor.EquipmentType = EquipmentConst.TYPESET_1.armor;
            cs1.Character.Armor.HitPoints = 10;
            cs1.Character.Armor.Speed = 10;
            cs1.Character.Armor.Attack = 10;
            cs1.Character.Armor.Defense = 10;
            cs1.Character.Hat = new NoManaEquipment();
            cs1.Character.Hat.Name = "Hat 1";
            cs1.Character.Hat.Description = "Hat 1 description";
            cs1.Character.Hat.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs1.Character.Hat.EquipmentType = EquipmentConst.TYPESET_1.hat;
            cs1.Character.Hat.HitPoints = 10;
            cs1.Character.Hat.Speed = 10;
            cs1.Character.Hat.Attack = 10;
            cs1.Character.Hat.Defense = 10;
            cs1.Character.Shoes = new NoManaEquipment();
            cs1.Character.Shoes.Name = "Shoes 1";
            cs1.Character.Shoes.Description = "Shoes 1 description";
            cs1.Character.Shoes.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs1.Character.Shoes.EquipmentType = EquipmentConst.TYPESET_1.shoes;
            cs1.Character.Shoes.HitPoints = 10;
            cs1.Character.Shoes.Speed = 10;
            cs1.Character.Shoes.Attack = 10;


            CharacterSystem cs2 = new CharacterSystem();
            cs2.Leveling = lvling1;
            cs2.Character = new Character();
            cs2.Character.Name = "Character2";
            cs2.Character.Description = "Character description here";
            cs2.Character.Stats = new NoManaStats();
            cs2.Character.Stats.HitPoints = 10;
            cs2.Character.Stats.Speed = 10;
            cs2.Character.Stats.Attack = 10;
            cs2.Character.Stats.Defense = 10;
            cs2.Character.CharacterClass = new NoManaCharacterClass();
            cs2.Character.CharacterClass.Name = "Chararcter Class 1";
            cs2.Character.CharacterClass.Description = "Character Class 1 description";
            cs2.Character.Stats.HitPoints = 10;
            cs2.Character.Stats.Speed = 10;
            cs2.Character.Stats.Attack = 10;
            cs2.Character.Stats.Defense = 10;
            cs2.Character.Level = new SimpleLevel();
            cs2.Character.Level.Level = 1;
            cs2.Character.Level.Experience = 0;
            cs2.Character.Weapon = new NoManaWeapon();
            cs2.Character.Weapon.Name = "Weapon 1";
            cs2.Character.Weapon.Description = "Weapon 1 description";
            cs2.Character.Weapon.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs2.Character.Weapon.EquipmentWeaponSet = EquipmentConst.WEAPONSET_1.sword;
            cs2.Character.Weapon.HitPoints = 10;
            cs2.Character.Weapon.Speed = 10;
            cs2.Character.Weapon.Attack = 10;
            cs2.Character.Weapon.Defense = 10;
            cs2.Character.Armor = new NoManaEquipment();
            cs2.Character.Armor.Name = "Armor 1";
            cs2.Character.Armor.Description = "Arnor 1 description";
            cs2.Character.Armor.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs2.Character.Armor.EquipmentType = EquipmentConst.TYPESET_1.armor;
            cs2.Character.Armor.HitPoints = 10;
            cs2.Character.Armor.Speed = 10;
            cs2.Character.Armor.Attack = 10;
            cs2.Character.Armor.Defense = 10;
            cs2.Character.Hat = new NoManaEquipment();
            cs2.Character.Hat.Name = "Hat 1";
            cs2.Character.Hat.Description = "Hat 1 description";
            cs2.Character.Hat.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs2.Character.Hat.EquipmentType = EquipmentConst.TYPESET_1.hat;
            cs2.Character.Hat.HitPoints = 10;
            cs2.Character.Hat.Speed = 10;
            cs2.Character.Hat.Attack = 10;
            cs2.Character.Shoes = new NoManaEquipment();
            cs2.Character.Shoes.Name = "Shoes 1";
            cs2.Character.Shoes.Description = "Shoes 1 description";
            cs2.Character.Shoes.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs2.Character.Shoes.EquipmentType = EquipmentConst.TYPESET_1.shoes;
            cs2.Character.Shoes.HitPoints = 10;
            cs2.Character.Shoes.Speed = 10;
            cs2.Character.Shoes.Attack = 10;


            CharacterSystem cs3 = new CharacterSystem();
            cs3.Leveling = lvling1;
            cs3.Character = new Character();
            cs3.Character.Name = "Character3";
            cs3.Character.Description = "Character description here";
            cs3.Character.Stats = new NoManaStats();
            cs3.Character.Stats.HitPoints = 10;
            cs3.Character.Stats.Speed = 10;
            cs3.Character.Stats.Attack = 10;
            cs3.Character.Stats.Defense = 10;
            cs3.Character.CharacterClass = new NoManaCharacterClass();
            cs3.Character.CharacterClass.Name = "Chararcter Class 1";
            cs3.Character.CharacterClass.Description = "Character Class 1 description";
            cs3.Character.Stats.HitPoints = 10;
            cs3.Character.Stats.Speed = 10;
            cs3.Character.Stats.Attack = 10;
            cs3.Character.Stats.Defense = 10;
            cs3.Character.Level = new SimpleLevel();
            cs3.Character.Level.Level = 1;
            cs3.Character.Level.Experience = 0;
            cs3.Character.Weapon = new NoManaWeapon();
            cs3.Character.Weapon.Name = "Weapon 1";
            cs3.Character.Weapon.Description = "Weapon 1 description";
            cs3.Character.Weapon.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs3.Character.Weapon.EquipmentWeaponSet = EquipmentConst.WEAPONSET_1.sword;
            cs3.Character.Weapon.HitPoints = 10;
            cs3.Character.Weapon.Speed = 10;
            cs3.Character.Weapon.Attack = 10;
            cs3.Character.Weapon.Defense = 10;
            cs3.Character.Armor = new NoManaEquipment();
            cs3.Character.Armor.Name = "Armor 1";
            cs3.Character.Armor.Description = "Arnor 1 description";
            cs3.Character.Armor.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs3.Character.Armor.EquipmentType = EquipmentConst.TYPESET_1.armor;
            cs3.Character.Armor.HitPoints = 10;
            cs3.Character.Armor.Speed = 10;
            cs3.Character.Armor.Attack = 10;
            cs3.Character.Armor.Defense = 10;
            cs3.Character.Hat = new NoManaEquipment();
            cs3.Character.Hat.Name = "Hat 1";
            cs3.Character.Hat.Description = "Hat 1 description";
            cs3.Character.Hat.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs3.Character.Hat.EquipmentType = EquipmentConst.TYPESET_1.hat;
            cs3.Character.Hat.HitPoints = 10;
            cs3.Character.Hat.Speed = 10;
            cs3.Character.Hat.Attack = 10;
            cs3.Character.Shoes = new NoManaEquipment();
            cs3.Character.Shoes.Name = "Shoes 1";
            cs3.Character.Shoes.Description = "Shoes 1 description";
            cs3.Character.Shoes.EquipmentWeight = EquipmentConst.WEIGHT.medium;
            cs3.Character.Shoes.EquipmentType = EquipmentConst.TYPESET_1.shoes;
            cs3.Character.Shoes.HitPoints = 10;
            cs3.Character.Shoes.Speed = 10;
            cs3.Character.Shoes.Attack = 10;

            List<CharacterSystem> systems = new List<CharacterSystem> { cs1, cs2, cs3 };

            loader.Write(path, systems);


        }
    }
}
