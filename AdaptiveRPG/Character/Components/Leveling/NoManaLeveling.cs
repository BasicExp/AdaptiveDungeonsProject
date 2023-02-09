namespace AdaptiveRPG.Character.Components.Leveling
{
    public class NoManaLeveling
    {
        public int Level { get; private set; } = 1;
        public int Experience { get; private set; } = 0;

        // Only the level experience array should need setting
        public int[] LevelExperience;
        public int MaxLevel { get; }

        public NoManaLeveling(int[] levelExperience)
        {
            LevelExperience = levelExperience;
            MaxLevel = LevelExperience.Length;
        }

        private bool updateLevel() { 
            if (Level == MaxLevel)
            {
                return false;
            }

            if (Experience >= LevelExperience[Level])
            {
                Level++;
                return true;
            }
            return false;
        }

        public bool addExperience(int experience)
        {
            Experience += experience;
            return this.updateLevel();
        }
    }
}
