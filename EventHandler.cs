using System;
using System.Collections.Generic;

namespace TwistyRoad;
internal class EventHandler
{
    public void HandleStart(Event e, Character character)
    {
        Console.WriteLine(e.Text);
        var name = Console.ReadLine();
        character.Name = name;
    }
    public void HandleClassChoice(Event e, Character character)
    {

        Console.WriteLine(e.Text);
        string playerInput = Console.ReadLine();
        int input = int.Parse(playerInput);
        if (input == 1)
        {
            character.Class = CharacterClass.Warrior;
            character.Attack = 10;
            character.Defence = 10;
            Console.WriteLine("This is what dreams of heroism lead to.A push in the back, no words of farwell, and there you are — on the road.\n It’s your first time here, but the rules are known to every child: think clearly and watch your surroundings.Everything else can be solved with a trusty sword at your side.");
        }
        if (input == 2)
        {
            character.Class = CharacterClass.Archer;
            character.Attack = 15;
            character.Defence = 5;
            Console.WriteLine("This is what dreams of heroism lead to. A push in the back, no words of farwell, and there you are — on the road.\n It’s your first time here, but the rules are known to every child: There is no problem that cannot be solved with a well-timed arrow.");
        }
        if (input == 3)
        {
            Console.WriteLine("Too bad, You dont have talant to be a mage.");
        }
        if (input == 4)
        {
            character.Class = CharacterClass.Bard;
            character.Attack = 8;
            character.Defence = 5;
            Console.WriteLine("Maybe I shouldn’t have drunk so much yesterday. A thought that crosses the mind of anyone suffering from a hangover. Well, here you are on the road, and indeed, drinking wasn’t worth it.");
        }

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
    public void HandleGamend(Event e, Character character)
    {

    }
}
