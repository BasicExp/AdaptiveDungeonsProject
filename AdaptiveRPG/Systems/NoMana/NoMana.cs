using AdaptiveRPG.Character.Components.Abilities;
using System.Xml.Serialization;

namespace AdaptiveRPG.Systems.NoMana
{
    public class NoManaSystem
    {
        [XmlArrayItem("Ability")]
        public List<NoManaAbility> Abilities { get; set; }

        [XmlArray("Classes")]
        [XmlArrayItem("System")]
        public List<CharacterClassSystem> CharacterClassSystems { get; set; }

        [XmlArray("Characters")]
        [XmlArrayItem("System")]
        public List<CharacterSystem> CharacterSystems { get; set; }

        [XmlArray("Leveling")]
        [XmlArrayItem("System")]
        public List<LevelingSystem> LevelingSystems { get; set; }
    }
}
