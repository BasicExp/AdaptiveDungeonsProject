using AdaptiveRPG.Character.Components.CharacterClasses;
using AdaptiveRPG.Character.Components.Equipment;
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

    public class EquipmentWeightModifier
    {
        public EquipmentConst.EQUIPMENT_WEIGHTS_1 Weight { get; set; }
        public double Modifier { get; set; }
    }

    public class WeaponTypeModifier
    {
        public EquipmentConst.EQUIPMENT_WEAPONSET_1 Type { get; set; }
        public double Modifier { get; set; }
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

        [XmlArrayItem("Modifier")]
        public List<EquipmentWeightModifier> EquimentWeightModifiers { get; set; }

        [XmlArrayItem("Modifier")]
        public List<WeaponTypeModifier> WeaponTypeModifiers { get; set; }
    }
}