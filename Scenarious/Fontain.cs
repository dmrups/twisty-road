namespace TwistyRoad.Scenarious;

internal static class Fontain
{
    public static Dictionary<string, Leaf> Scenario = new()
    {
        {
            CharacterClass.Warrior.ToString(),
            new Leaf
            {
                Text = "\n\n1.Look around. There may be something dangerous nearby.\n2.Come closer and drink some water.\n3.Kneel and offer prayers.\n4.Ignore and proceed.",
            }
        },
        {
            CharacterClass.Warrior.ToString() + "1",
            new Leaf
            {
                Text = "\"You look around but everething seems pretty safe.\n1.Drink from fontain.\n2.Kneel and offer prayers.\n3.Ignore and proceed.\"",
            }
        },
        {
            CharacterClass.Warrior.ToString() + "11",
            new Leaf {
                Text = "Water is cold and tasty. It fills you with vigor. You feel healed.\n You restored {0} health.\n1.Kneel and offer prayers.\n2.Walk forth.",
                CharacterAction = c => c.RestoreHealth(),
                TextAction = c => (c.MaxHealth - c.Health).ToString(),
            }
        },
        {
            CharacterClass.Warrior.ToString() + "111",
            new Leaf {
                Text = "You prayed for half an hour, but still did not catch a response, nevertheless, the time was well spent thought.\n Anyway you have nothing left to do in this place, so you continue your jorney.",
                DialogExit = true,
            }
        },
         {
            CharacterClass.Warrior.ToString() + "112",
            new Leaf {
                Text = "You left place with fontain, to continue your jorney.",
                DialogExit = true,
            }
        },
          {
            CharacterClass.Warrior.ToString() + "2",
            new Leaf {
                Text = "Water is cold and tasty. It fills you with vigor. You feel healed.\n You restored {0} health\n\n1.Kneel and offer prayers.\n2.Ignore and proceed.",
                CharacterAction = c => c.RestoreHealth(),
                TextAction = c => (c.MaxHealth - c.Health).ToString(),
            }
        },
          {
            CharacterClass.Warrior.ToString() + "21",
            new Leaf {
                Text = "You prayed for half an hour, but still did not catch a response, nevertheless, the time was well spent thought.\n Anyway you have nothing left to do in this place, so you continue your jorney.",
                DialogExit = true,
            }
        },
          {
            CharacterClass.Warrior.ToString() + "22",
            new Leaf {
                Text = "You left place with fontain, to continue your jorney.",
                DialogExit = true,
            }
        },
          {
            CharacterClass.Warrior.ToString() + "3",
            new Leaf {
                Text = "You kneel before a fountain and pray. As you concentrated on your prayers, u can feel sacred energy flow throught your body. You feel empowered.\n\n1.Drink some water.\n2.Ignore and proceed..",
                CharacterAction = c => c.PrayerBuff(),
            }
        },
        {
            CharacterClass.Warrior.ToString() + "31",
            new Leaf {
                Text = "The water is cold and tasty, it's a good water. \n Anyway you have nothing left to do in this place, so you continue your jorney. ",
                DialogExit = true,
            }
        },
        {
            CharacterClass.Warrior.ToString() + "32",
            new Leaf {
                Text = "You left place with fontain, to continue your jorney.",
                DialogExit = true,
            }
        },
        {
            CharacterClass.Warrior.ToString() + "4",
            new Leaf {
                Text = "You have nothing to do in this place, so you leaving to continue your jorney.",
                DialogExit = true,
            }
        },
    };
}
