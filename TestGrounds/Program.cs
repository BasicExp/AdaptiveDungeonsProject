using TestGrounds.AdaptiveRPG.NoMana;

// This actually not what I want to be doing I do not think
// What I want to be doing is reading in an XML file that dynamically builds 
// the "CharacterSystem" class based on the values

// The strucuture of the XML should be consitent with some values being optional
// but the structure/behaviour of the resulting class should be dynamic

// I am going back and forth. I think this is what I want, and that the plug
// and play will come at the level of being able to mess around with different
// battle systems, narrative systems with different character systems.

NoManaTestGround.CreateSampleCharacterSystem("NoManaSystem.xml");
NoManaTestGround.LoadSampleCharacterSystem("NoManaSystem.xml");