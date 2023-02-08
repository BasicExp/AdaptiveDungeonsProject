namespace AdaptiveRPG.NoManaRPG
{
    public class Character
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int HitPoints { get; private set; }
        public int Speed { get; private set; }
        public int Attack { get; private set; }
        public int Defense { get; private set; }

        public Character(string name, string description, int hitPoints, int speed, int attack, int defense, object weapon, object hat, object armor, object shoes, CharacterClass characterClass)
        {
            Name = name;
            Description = description;
            HitPoints = hitPoints;
            Speed = speed;
            Attack = attack;
            Defense = defense;
            Weapon = weapon;
            Hat = hat;
            Armor = armor;
            Shoes = shoes;
            CharacterClass = characterClass;
        }



        // TODO - Change to use classes
        public object Weapon { get; set; }
        public object Hat { get; set; }
        public object Armor { get; set; }
        public object Shoes { get; set; }
        public CharacterClass CharacterClass { get; set; }

    }
}