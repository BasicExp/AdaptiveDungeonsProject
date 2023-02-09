namespace AdaptiveRPG.Character.Systems.NoMana
{
    public class CharacterClassUpgrader
    {
        private string _xmlFilePath;
        private Dictionary<string, string[]>? _upgradePaths;

        public CharacterClassUpgrader(string xmlFilePath) { 
            _xmlFilePath = xmlFilePath;
            loadXML();
        }

        private void loadXML()
        {
            // TODO - This is where I left off, I think this will live in
            // a seperate loader class that does all loading for this 
            // RPG system
            _upgradePaths = new Dictionary<string, string[]>();
        }
    }
}
