using AdaptiveRPG.Character.Components.Abilities;
using AdaptiveRPG.Character.Components.Leveling;

namespace AdaptiveRPG.Systems.NoMana
{
    public class CharacterManager
    {
        private readonly int MaxLevel;

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
            MaxLevel = LevelingSystem.Levels.MaxBy(l => l.Level).Level;
        }

        public int Level { get { return CharacterSystem.Level.Level; } }
        public int Experience { get { return CharacterSystem.Level.Experience; } }

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

        public int HealthPoints
        {
            get
            {
                return CharacterSystem.Stats.HitPoints + ClassSystem.CharacterClass.HitPoints + CharacterSystem.Weapon.HitPoints +
                    CharacterSystem.Armor.HitPoints + CharacterSystem.Hat.HitPoints + CharacterSystem.Shoes.HitPoints;
            }
        }

        public int Speed
        {
            get
            {
                return CharacterSystem.Stats.Speed + ClassSystem.CharacterClass.Speed + CharacterSystem.Weapon.Speed +
                    CharacterSystem.Armor.Speed + CharacterSystem.Hat.Speed + CharacterSystem.Shoes.Speed;
            }
        }

        public List<NoManaAbility> AvailableAbilities
        {
            get
            {
                return ClassSystem.CharacterClassAbilities
                    .FindAll(a => a.RequiredLevel <= CharacterSystem.Level.Level)
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

        private int updateLevel()
        {
            if (CharacterSystem.Level.Level == MaxLevel)
            {
                return CharacterSystem.Level.Level;
            }

            SimpleLevel? nextLevel = LevelingSystem.Levels.Find((a) => a.Level == CharacterSystem.Level.Level + 1);

            if (nextLevel == null)
            {
                throw new NullReferenceException($"No entry for level {CharacterSystem.Level.Level + 1} found for {CharacterSystem.Character.Name}");
            }

            return CharacterSystem.Level.Level = nextLevel.Level;
        }

        public int addExperience(int experience)
        {
            CharacterSystem.Level.Experience += experience;
            return updateLevel();
        }

    }
}
