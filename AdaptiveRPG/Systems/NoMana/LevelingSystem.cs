using AdaptiveRPG.Character.Components.Leveling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptiveRPG.Systems.NoMana
{
    public class LevelingSystem
    {
        public string Name { get; set; }
        public List<SimpleLevel>? Levels { get; set; }
    }
}
