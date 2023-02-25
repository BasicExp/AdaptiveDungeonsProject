using AdaptiveRPG.Systems.NoMana;

namespace TestGrounds.AdaptiveRPG.NoMana
{
    public class NoManaTestGround
    {

        public static void HappyPath()
        {
            // Test Reading/Writing XML
            NoManaSystem noManaSystem = SystemManager.CreateSampleSystem();
            SystemManager system = new SystemManager(noManaSystem);
            system.save("NoManaSystem.xml");
            system = SystemManager.LoadFromFile("NoManaSystem.xml");

            foreach ((string k, CharacterSystem v) in system.CharacterSystems)
            {
                // Test Instantiating
                CharacterManager cm = new CharacterManager(k, system);
                // Test Leveling
                while (cm.Level < cm.MaxLevel.Level)
                {
                    cm.addExpereience(5);
                    Console.WriteLine($"[{cm.Name}][Level:{cm.Level}][Experience:{cm.Experience}]");
                }
                // Test Equipment Resolution
                Console.WriteLine($"[{cm.Name}][Weapon:{cm.Weapon.Name}][Armor:{cm.Armor.Name}][Shoes:{cm.Shoes.Name}][Hat:{cm.Hat.Name}]");
                // Test Stat Resolution after Class Based Equipment Mods
                Console.WriteLine($"[{cm.Name}][Attack:{cm.Attack}][Defense:{cm.Defense}][Speed:{cm.Speed}][HP:{cm.HitPoints}]");
                // Test changing euqipment, fragile if CreateSampleSystem changes
                cm.equip(system.Weapons["Weapon 2"]);
            }

            // Test persisting state
            system.save("NoManaSystemUpdated.xml");
        }
    }
}
