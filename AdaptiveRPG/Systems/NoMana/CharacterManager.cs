using AdaptiveRPG.Character.Components.Leveling;

namespace AdaptiveRPG.Systems.NoMana
{
    /// <summary>
    /// This class seperates the structure of the Character from logic that would result in
    /// the mutation of the values. This is done to help keep serialization comprehensible
    /// as well as to restrict access to character fields after instantiation.
    /// </summary>
    public class CharacterManager
    {
        private CharacterSystem CS { get; set; }
        private readonly int MaxLevel;

        public CharacterManager(CharacterSystem characterSystem)
        {
            CS = characterSystem;
            MaxLevel = CS.Leveling.Levels.MaxBy(l => l.Level).Level;
        }

        public int Attack
        {
            get
            {
                return CS.Stats.Attack + CS.CharacterClass.Attack + CS.Weapon.Attack +
                    CS.Armor.Attack + CS.Hat.Attack + CS.Shoes.Attack;
            }
        }

        public int Defense
        {
            get
            {
                return CS.Stats.Defense + CS.CharacterClass.Defense + CS.Weapon.Defense +
                    CS.Armor.Defense + CS.Hat.Defense + CS.Shoes.Defense;
            }
        }


        private int updateLevel()
        {
            if (CS.Level.Level == MaxLevel)
            {
                return CS.Level.Level;
            }

            SimpleLevel? nextLevel = CS.Leveling.Levels.Find((a) => a.Level == CS.Level.Level + 1);

            if (nextLevel == null)
            {
                throw new NullReferenceException($"No entry for level {CS.Level.Level + 1} found for {CS.Character.Name}");
            }

            return CS.Level.Level = nextLevel.Level;
        }

        /// <summary>
        /// Add experience to the Character's expereince pool
        /// </summary>
        /// <param name="experience">The amount of experience to add</param>
        /// <returns>Character level after experience is applied</returns>
        public int addExperience(int experience)
        {
            CS.Level.Experience += experience;
            return updateLevel();
        }

    }
}
