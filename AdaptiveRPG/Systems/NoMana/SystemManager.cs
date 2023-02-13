using AdaptiveRPG.Character.Components.Abilities;
using AdaptiveRPG.Character.Components.Leveling;

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
        public readonly Dictionary<string, CharacterClassSystem> CharacterClassSystems;
        public readonly Dictionary<string, CharacterSystem> CharacterSystems;
        public readonly Dictionary<string, LevelingSystem> LevelingSystems;

        public SystemManager(NoManaSystem noManaSystem)
        {
            Abilities = new Dictionary<string, NoManaAbility>();
            CharacterClassSystems = new Dictionary<string, CharacterClassSystem>();
            CharacterSystems = new Dictionary<string, CharacterSystem>();
            LevelingSystems = new Dictionary<string, LevelingSystem>();

            noManaSystem.Abilities.ForEach(a => { Abilities.Add(a.Name, a); });
            noManaSystem.CharacterClassSystems.ForEach(ccs => { CharacterClassSystems.Add(ccs.CharacterClass.Name, ccs); });
            noManaSystem.CharacterSystems.ForEach(cs => { CharacterSystems.Add(cs.Character.UniqueId, cs); });
            noManaSystem.LevelingSystems.ForEach(ls => { LevelingSystems.Add(ls.Name, ls); });

        }

    }
}
