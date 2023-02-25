namespace AdaptiveRPG.Character.Components.Leveling
{

    public class SimpleLevel : IComparable<SimpleLevel>
    {
        public int Level { get; set; }
        public int Experience { get; set; }

        public int CompareTo(SimpleLevel? other)
        {
            return this.Level - other.Level;
        }
    }

}
