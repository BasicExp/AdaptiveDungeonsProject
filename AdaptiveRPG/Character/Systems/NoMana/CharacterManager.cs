using AdaptiveRPG.Character.Components.Leveling;
using AdaptiveRPG.Systems.Util;
using System.Reflection.Emit;

namespace AdaptiveRPG.Character.Systems.NoMana
{
    /// <summary>
    /// This class seperates the structure of the Character from logic that would result in
    /// the mutation of the values. This is done to help keep serialization comprehensible
    /// as well as to restrict access to character fields after instantiation.
    /// </summary>
    public class CharacterManager
    {
        private CharacterSystem CharacterSystem { get; set; }
        private readonly int MaxLevel;

        private Character Character { get { return CharacterSystem.Character; } }
        private SimpleLeveling Leveling { get { return CharacterSystem.Leveling; } }

        public CharacterManager(CharacterSystem characterSystem)
        {
            CharacterSystem = characterSystem;
            MaxLevel = CharacterSystem.Leveling.Levels.MaxBy(l => l.Level).Level;
        }

        public int Attack
        {
            get
            {
                return Character.Stats.Attack + Character.CharacterClass.Attack + Character.Weapon.Attack +
                    Character.Armor.Attack + Character.Hat.Attack + Character.Shoes.Attack;
            }
        }

        public int Defense
        {
            get
            {
                return Character.Stats.Defense + Character.CharacterClass.Defense + Character.Weapon.Defense +
                    Character.Armor.Defense + Character.Hat.Defense + Character.Shoes.Defense;
            }
        }


        private int updateLevel()
        {
            if (Character.Level.Level == MaxLevel)
            {
                return Character.Level.Level;
            }

            SimpleLevel? nextLevel = Leveling.Levels.Find((a) => a.Level == Character.Level.Level + 1);

            if (nextLevel == null)
            {
                throw new NullReferenceException($"No entry for level {Character.Level.Level + 1} found for {Character.Name}");
            }

            return Character.Level.Level = nextLevel.Level;
        }

        /// <summary>
        /// Add experience to the Character's expereince pool
        /// </summary>
        /// <param name="experience">The amount of experience to add</param>
        /// <returns>Character level after experience is applied</returns>
        public int addExperience(int experience)
        {
            Character.Level.Experience += experience;
            return this.updateLevel();
        }

    }
}
