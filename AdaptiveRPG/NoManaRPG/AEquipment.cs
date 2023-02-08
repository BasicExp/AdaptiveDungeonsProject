namespace AdaptiveRPG.NoManaRPG
{
    public abstract class AEquipment
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string EquipmentType { get; private set; }

        // Private members
        private int Level { get; set; }
        private int HitPoints { get; set; }
        private int Speed { get; set; }
        private int Attack { get; set; }
        private int Defense { get; set; }

        public AEquipment(string name, string description, string equipmentType, int level, int hitPoints, int speed, int attack, int defense)
        {
            Name = name;
            Description = description;
            EquipmentType = equipmentType;
            Level = level;
            HitPoints = hitPoints;
            Speed = speed;
            Attack = attack;
            Defense = defense;
        }

        public abstract int abilityModifier(AAbility abiltity);
    }
}