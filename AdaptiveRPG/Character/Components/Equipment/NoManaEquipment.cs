namespace AdaptiveRPG.Character.Components.Equipment
{
    public class NoManaEquipment
    {
        public EquipmentConst.WEIGHT EquipmentWeight { get; set; }
        public EquipmentConst.TYPESET_1 EquipmentType { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Level { get; set; }
        public int HitPoints { get; set; }
        public int Speed { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
    }


    public class NoManaWeapon : NoManaEquipment
    {
        public EquipmentConst.WEAPONSET_1 EquipmentWeaponSet { get; set;}
        
        public NoManaWeapon() {
            EquipmentType = EquipmentConst.TYPESET_1.weapon;
        }
    }
}
