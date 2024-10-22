using TwistyRoad;

Event[] story =
[
    new Event
    {
        Type = EventType.Start,
        Name = "Opening",
        Text = "Hello, travaler! What is your name ?."
    },
    new Event
    {
        Type = EventType.ClassChoice,
        Name = "Choice",
        Text ="Make your choice  before starting an adventure.\n" +
        "\n"+
        "1. Warrior, the one with a sword.\n"+
        "2. Archer who armed with a bow and suspicious amount of arrows.\n"+
        "3. Mage, master of mystic forces.\n"+
        "4. Bard, who has a lyre and high hopes for future. He also carries a dagger.\n",
    },
    new Event
    {
        Type = EventType.RoadStart,
        Name = "FirstStep",
    },
    new Event
    {
        Type = EventType.Finish,
        Name = "Closing",
        Text = "{0} died"
    }
];

Character mainCharacter = new();
TwistyRoad.EventHandler handler = new();

foreach (Event e in story)
{
    if (mainCharacter.Health > 0)
    {
        handler.HandleGamend(e, mainCharacter);
        
    }
    switch (e.Type)
    {
        case EventType.Start: 
            handler.HandleStart(e, mainCharacter);
            break;
        case EventType.ClassChoice:
            handler.HandleClassChoice(e, mainCharacter);
            break;  
        case EventType.Finish: 
            handler.HandleFinish(e, mainCharacter);
            break;
        case EventType.Fight: 
            handler.HandleFight(e, mainCharacter);
            break;
        case EventType.Explore: 
            handler.HandleExplore(e, mainCharacter);
            break;
        case EventType.Dialog: 
            handler.HandleDialog(e, mainCharacter);
            break;
        case EventType.Gamend:
            handler.HandleGamend(e, mainCharacter);
            break;
    }
}
