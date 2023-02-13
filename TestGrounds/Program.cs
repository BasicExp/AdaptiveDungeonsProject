using AdaptiveRPG.Systems.NoMana;
using TestGrounds.AdaptiveRPG.NoMana;

// NoMana Happy Path
NoManaTestGround.CreateSampleCharacterSystem("NoManaSystem.xml");
SystemManager system = new SystemManager(NoManaTestGround.LoadSampleCharacterSystem("NoManaSystem.xml"));
foreach ((string k, CharacterSystem v) in system.CharacterSystems)
{
    CharacterManager cm = new CharacterManager(k, system);
}

// TODO - Finish CharacterManager logic
// TODO - Add equipment manager?