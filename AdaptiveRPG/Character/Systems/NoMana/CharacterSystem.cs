using AdaptiveRPG.Character.Components.Leveling;

namespace AdaptiveRPG.Character.Systems.NoMana
{
    public class CharacterSystem
    {
        [System.Xml.Serialization.XmlElement("Characters")]
        public List<Character>? Characters { get; set; }
        public SimpleLeveling? Leveling { get; set; }
    }
}
