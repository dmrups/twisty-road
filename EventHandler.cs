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
            character.Health = 20;
            Console.WriteLine("This is what dreams of heroism lead to.A push in the back, no words of farwell, and there you are — on the road.\n It’s your first time here, but the rules are known to every child: think clearly and watch your surroundings.Everything else can be solved with a trusty sword at your side.");
        }
        if (input == 2)
        {
            character.Class = CharacterClass.Archer;
            character.Attack = 15;
            character.Defence = 5;
            character.Health = 10;
            Console.WriteLine("This is what dreams of heroism lead to. A push in the back, no words of farwell, and there you are — on the road.\n It’s your first time here, but the rules are known to every child: There is no problem that cannot be solved with a well-timed arrow.");
        }
        if (input == 3)
        {
            Console.WriteLine("Too bad, You dont have talant to be a mage.");
            return;
        }
        if (input == 4)
        {
            character.Class = CharacterClass.Bard;
            character.Attack = 8;
            character.Defence = 5;
            character.Health = 10;
            Console.WriteLine("Maybe I shouldn’t have drunk so much yesterday. A thought that crosses the mind of anyone suffering from a hangover. Well, here you are on the road, and indeed, drinking wasn’t worth it.");
        }

    }

    public void HandleFinish(Event e, Character character)
    {
        Console.WriteLine(string.Format(e.Text, character.Name));
    }

    public void HandleFight(Event e, Character character)

    {
        Console.WriteLine(string.Format(e.Text, e.Enemy.Name));
        
        int dodgeDefence = 0;
        while (character.Health > 0 && e.Enemy.Health > 0)
        {
            Console.WriteLine("\n1.Attack\n2.Dodge\n3.Run");

            string playerInput = Console.ReadLine();
            int input = int.Parse(playerInput);

            if (input == 1)
            {
                int damage = (int)Math.Floor(character.Attack * (100 - e.Enemy.Defence) / 100m);
                e.Enemy.Health -= damage;
                Console.WriteLine($"You strike {e.Enemy.Name} and deal {damage} damage to his health. He have {(e.Enemy.Health > 0 ? e.Enemy.Health : 0)} left.");
            }
            else if (input == 2)
            {
                dodgeDefence = character.Defence * 2;

            }
            else if (input == 3)
            {
                Random rnd = new Random();
                int runRandom = rnd.Next(3);
                if (runRandom == 0)
                {
                    Console.WriteLine("You were faster than your enemy, and got out unscratched. Lucky you.");
                    return;
                }
                if (runRandom == 1)
                {
                    Console.WriteLine("You weren't fast enough and got hit.");
                    character.Health -= e.Enemy.Attack;
                    return;
                }
                if (runRandom == 2)
                {
                    Console.WriteLine("You weren't fast enough and got hit. Ouch!");
                    character.Health -= e.Enemy.Attack;
                    character.Health -= e.Enemy.Attack;
                    return;
                }


                if (e.Enemy.Health < 1)
                {
                    break;
                }
            }
            int damageToCharacter = (int)Math.Floor(e.Enemy.Attack * ((100 - character.Defence - dodgeDefence) / 100m));
            dodgeDefence = 0;
            character.Health -= (damageToCharacter);

            Console.WriteLine($"{e.Enemy.Name} strikes you and deal {damageToCharacter} damage to your health. You have {(character.Health > 0 ? character.Health : 0)} left.");



        }
        if (e.Enemy.Health > 0)
        {
            Console.WriteLine($"{e.Enemy.Name} defeated you! ");
        }

        if (character.Health > 0)
        {
            Console.WriteLine($"You won this battle! {e.Enemy.Name} is dead!");
        }

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

    public void HandleContextFight(Event e, Character character, Context context)
    {

    }
}
