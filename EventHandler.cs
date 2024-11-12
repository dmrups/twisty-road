using TwistyRoad.Scenarious;

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
            character.MaxHealth = 20;
            character.Health = 20;
            Console.WriteLine("This is what dreams of heroism lead to.A push in the back, no words of farwell, and there you are — on the road.\n It’s your first time here, but the rules are known to every child: think clearly and watch your surroundings.Everything else can be solved with a trusty sword at your side.\n\n");
        }
        if (input == 2)
        {
            character.Class = CharacterClass.Archer;
            character.Attack = 15;
            character.Defence = 5;
            character.MaxHealth = 10;
            character.Health = 10;
            Console.WriteLine("This is what dreams of heroism lead to. A push in the back, no words of farwell, and there you are — on the road.\n It’s your first time here, but the rules are known to every child: There is no problem that cannot be solved with a well-timed arrow.\n\n");
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
            character.MaxHealth = 10;
            character.Health = 10;
            Console.WriteLine("Maybe I shouldn’t have drunk so much yesterday. A thought that crosses the mind of anyone suffering from a hangover. Well, here you are on the road, and indeed, drinking wasn’t worth it.\n\n");
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



            if (character.Class == CharacterClass.Bard)



                Console.WriteLine("\n1.Attack\n2.Dodge\n3.Run\n4.Take out your Lyre and start playing music");


            else
            {
                Console.WriteLine("\n1.Attack\n2.Dodge\n3.Run");
            }

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
                dodgeDefence = character.Defence * 4;

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
            else if ((character.Class == CharacterClass.Bard) && input == 4)
            {
                Console.WriteLine($"It seems that music isn't his liking. {e.Enemy.Name} hits you.");
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

    public void HandleFontain(Event e, Character character)

    {
        Console.WriteLine(e.Text);
        string playerInput;
        string address = character.Class.ToString();

        while (Fontain.Scenario.TryGetValue(address, out Leaf leaf))
        {
            if (leaf == null)
            {
                break;
            }

            string text;

            if (leaf.TextAction != null)
            {
                text = string.Format(leaf.Text, leaf.TextAction(character));
            }
            else
            {
                text = leaf.Text;
            }

            Console.WriteLine(text);
            playerInput = Console.ReadLine();

            if (leaf.ExitOption != null && leaf.ExitOption == playerInput)
            {
                address = "exit";
            }
            else
            {
                while (!Fontain.Scenario.ContainsKey(address + playerInput))
                {
                    Console.WriteLine("You missed the button");
                    playerInput = Console.ReadLine();
                }

                address += playerInput;
            }

            if (leaf.CharacterAction != null)
            {
                leaf.CharacterAction(character);
            }
        }
        /*

            if (character.Class == CharacterClass.Warrior)
        {


            Console.WriteLine("\n\n1.Look around. There may be something dangerous nearby.\n2.Come closer and drink some water.\n3.Kneel and offer prayers.\n4.Ignore and proceed.");
            playerInput = Console.ReadLine();




            if (playerInput == "1")
            {
                Console.WriteLine("You look around but everething seems pretty safe.\n1.Drink from fontain.\n2.Kneel and offer prayers.\n3.Ignore and proceed.");
                playerInput = Console.ReadLine();

                if (playerInput == "1")
                {
                    Console.WriteLine($"Water is cold and tasty. It fills you with vigor. You feel healed.\n You restored {character.MaxHealth - character.Health} health.\n1.Kneel and offer prayers.\n2.Walk forth.");
                    playerInput = Console.ReadLine();
                    character.Health = character.MaxHealth;

                    if (playerInput == "1")
                    {
                        Console.WriteLine("You prayed for half an hour, but still did not catch a response, nevertheless, the time was well spent thought.\n Anyway you have nothing left to do in this place, so you continue your jorney.");
                    }
                    if (playerInput == "2")
                    {
                        Console.WriteLine("You left place with fontain, to continue your jorney.");
                    }
                }

                else if (playerInput == "2")
                {
                    Console.WriteLine($"Water is cold and tasty. It fills you with vigor. You feel healed.\\n You restored {character.MaxHealth - character.Health} health\n\n1.Kneel and offer prayers.\n2.Ignore and proceed.");
                    playerInput = Console.ReadLine();

                    if (playerInput == "1")
                    {
                        Console.WriteLine("You prayed for half an hour, but still did not catch a response, nevertheless, the time was well spent thought.\n Anyway you have nothing left to do in this place, so you continue your jorney.");
                    }

                    if (playerInput == "2")
                    {
                        Console.WriteLine("You left place with fontain, to continue your jorney.");
                    }
                }

                else if (playerInput == "3")
                {
                    Console.WriteLine($"You kneel before a fountain and pray.\n\n1.Drink some water.\n2.Ignore and proceed.");
                    playerInput = Console.ReadLine();

                    if (playerInput == "1")
                    {
                        Console.WriteLine("You prayed for half an hour, but still did not catch a response, nevertheless, the time was well spent thought.\n Anyway you have nothing left to do in this place, so you continue your jorney.");
                    }

                    if (playerInput == "2")
                    {
                        Console.WriteLine("You left place with fontain, to continue your jorney.");
                    }
                }




            }
        }*/
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