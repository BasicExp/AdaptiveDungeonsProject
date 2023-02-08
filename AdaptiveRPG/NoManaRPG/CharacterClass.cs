using System.Security.Claims;

namespace AdaptiveRPG.NoManaRPG
{
    public class CharacterClass
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        // Private members
        private int Level { get; set; }
        private int HitPoints { get; set; }
        private int Speed { get; set; }
        private int Attack { get; set; }
        private int Defense { get; set; }

        // TODO - Change to use classes, probably wrapper classes
        private Dictionary<string, AAbility> Abilities { get; set; }
        private Dictionary<string, AEquipment> Equipment { get; set; }
        
        public CharacterClass(string name, string description, int hitPoints, int speed, int attack, int defense)
        {
            Name = name;
            Description = description;
            HitPoints = hitPoints;
            Speed = speed;
            Attack = attack;
            Defense = defense;
            // TODO - Add these to the constructor or instantiate them sensibly
            Abilities = new Dictionary<string, AAbility>();
            Equipment = new Dictionary<string, AEquipment>();
        }

    }
}