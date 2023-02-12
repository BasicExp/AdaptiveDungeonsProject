namespace AdaptiveRPG.Character.Components.Leveling
{

    public class SimpleLevel
    {
        public int Level { get; set; }
        public int Experience { get; set; }
    }

    public class SimpleLeveling
    { 
        // This may seem verbose, but we are using logic like this to result in 
        // as easy to write and understand XML as possible.
        public List<SimpleLevel>? Levels { get; set; }
    }
}
