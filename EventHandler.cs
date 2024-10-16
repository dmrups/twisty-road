namespace TwistyRoad;
internal class EventHandler
{
    public void HandleStart(Event e, Character character)
    {
        Console.WriteLine(e.Text);
        var name = Console.ReadLine();
        character.Name = name;
    }

    public void HandleFinish(Event e, Character character)
    {
        Console.WriteLine(string.Format(e.Text, character.Name));
    }

    public void HandleFight(Event e, Character character)
    {

    }

    public void HandleExplore(Event e, Character character)
    {

    }

    public void HandleDialog(Event e, Character character)
    {

    }
}
