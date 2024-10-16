using TwistyRoad;

Event[] story =
[
    new Event
    {
        Type = EventType.Start,
        Name = "Opening",
        Text = "Hello, travaler! Choose you class before starting an adventure."
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
    switch (e.Type)
    {
        case EventType.Start: 
            handler.HandleStart(e, mainCharacter);
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
    }
}
