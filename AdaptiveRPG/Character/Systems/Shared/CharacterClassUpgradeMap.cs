using AdaptiveRPG.Character.Components.CharacterClasses;

namespace AdaptiveRPG.Character.Systems.Shared
{
    /// <summary>
    /// Used to define upgrade paths for classes in relation to one another generically, with no knowledge
    /// of how the character classes work internally
    /// </summary>
    /// <typeparam name="CharacterClass">The C# class that represents character classes for the system</typeparam>
    public class CharacterClassUpgradeMap<CharacterClass>
    {
        // This could be a Dictionary of Dictionaries but I am not sure if it would
        // make a meaningful difference performance wise. Leaving it as it is because
        // I think lists are more comprenhensible when it will come the XML parsing 
        private Dictionary<string, List<CharacterClass>> _classUpgradeMap = new Dictionary<string, List<CharacterClass>>();

        public List<CharacterClass> Get(string baseClassName)
        {
            if (!_classUpgradeMap.ContainsKey(baseClassName))
            {
                _classUpgradeMap.Add(baseClassName, new List<CharacterClass>());
            }
            return _classUpgradeMap[baseClassName];
        }

        public void Add(string baseClassName, CharacterClass upgradeClass)
        {
            Get(baseClassName).Add(upgradeClass);
        }

    }
}
