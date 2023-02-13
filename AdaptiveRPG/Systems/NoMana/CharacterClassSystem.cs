using AdaptiveRPG.Character.Components.CharacterClasses;
using System.Xml.Serialization;

namespace AdaptiveRPG.Systems.NoMana
{
    public class CharacterClassAbility
    {
        public int RequiredLevel { get; set; }
        public string? Name { get; set; }
    }

    public class CharacterClassUpgrade
    {
        public int RequiredLevel { get; set; }
        public string? Name { get; set; }
    }

    public class CharacterClassSystem
    {
        [XmlElement("Class")]
        public NoManaCharacterClass? CharacterClass { get; set; }

        [XmlArray("Abilities")]
        [XmlArrayItem("Ability")]
        public List<CharacterClassAbility>? CharacterClassAbilities { get; set; }

        [XmlArray("Upgrades")]
        [XmlArrayItem("Class")]
        public List<CharacterClassUpgrade>? ChararcterClassUpgrades { get; set; }
    }
}