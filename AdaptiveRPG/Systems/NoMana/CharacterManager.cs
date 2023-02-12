using AdaptiveRPG.Character.Components.Leveling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptiveRPG.Systems.NoMana
{
    public class CharacterManager
    {
        private readonly int MaxLevel;

        private SystemManager SystemManager;
        private CharacterSystem CharacterSystem;
        private CharacterClassSystem ClassSystem;


        public CharacterManager(string characterUniqueId, SystemManager systemManager)
        {
            SystemManager = systemManager;
            CharacterSystem = SystemManager.CharacterSystems[characterUniqueId];
            ClassSystem = SystemManager.CharacterClassSystems[CharacterSystem.CharacterClassSystem];
            MaxLevel = CharacterSystem.Leveling.Levels.MaxBy(l => l.Level).Level;
        }

        public int Attack
        {
            get
            {
                return CharacterSystem.Stats.Attack + ClassSystem.CharacterClass.Attack + CharacterSystem.Weapon.Attack +
                    CharacterSystem.Armor.Attack + CharacterSystem.Hat.Attack + CharacterSystem.Shoes.Attack;
            }
        }

        public int Defense
        {
            get
            {
                return CharacterSystem.Stats.Defense + ClassSystem.CharacterClass.Defense + CharacterSystem.Weapon.Defense +
                    CharacterSystem.Armor.Defense + CharacterSystem.Hat.Defense + CharacterSystem.Shoes.Defense;
            }
        }


        private int updateLevel()
        {
            if (CharacterSystem.Level.Level == MaxLevel)
            {
                return CharacterSystem.Level.Level;
            }

            SimpleLevel? nextLevel = CharacterSystem.Leveling.Levels.Find((a) => a.Level == CharacterSystem.Level.Level + 1);

            if (nextLevel == null)
            {
                throw new NullReferenceException($"No entry for level {CharacterSystem.Level.Level + 1} found for {CharacterSystem.Character.Name}");
            }

            return CharacterSystem.Level.Level = nextLevel.Level;
        }

        /// <summary>
        /// Add experience to the Character's expereince pool
        /// </summary>
        /// <param name="experience">The amount of experience to add</param>
        /// <returns>Character level after experience is applied</returns>
        public int addExperience(int experience)
        {
            CharacterSystem.Level.Experience += experience;
            return updateLevel();
        }
    }
}
