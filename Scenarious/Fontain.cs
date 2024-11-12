namespace TwistyRoad.Scenarious;

internal static class Fontain
{
    public static Dictionary<string, Leaf> Scenario = new()
    {
        {
            "exit",
            null
        },
        {
            CharacterClass.Warrior.ToString(),
            new Leaf
            {
                Text = "\n\n1.Look around. There may be something dangerous nearby.\n2.Come closer and drink some water.\n3.Kneel and offer prayers.\n4.Ignore and proceed.",
                ExitOption = "4",
            }
        },
        {
            CharacterClass.Warrior.ToString() + "1",
            new Leaf
            {
                Text = "\"You look around but everething seems pretty safe.\n1.Drink from fontain.\n2.Kneel and offer prayers.\n3.Ignore and proceed.\"",
                ExitOption = "3",
            }
        },
        {
            CharacterClass.Warrior.ToString() + "2",
            new Leaf {
                Text = "Water is cold and tasty. It fills you with vigor. You feel healed.\n You restored {0} health\n\n1.Kneel and offer prayers.\n2.Ignore and proceed.",
                CharacterAction = c => c.RestoreHealth(),
                TextAction = c => (c.MaxHealth - c.Health).ToString(),
                ExitOption = "2",
            }
        },
        {
            CharacterClass.Warrior.ToString() + "11",
            new Leaf {
                Text = "Water is cold and tasty. It fills you with vigor. You feel healed.\n You restored {0} health.\n1.Kneel and offer prayers.\n2.Walk forth.",
                CharacterAction = c => c.RestoreHealth(),
                TextAction = c => (c.MaxHealth - c.Health).ToString(),
                ExitOption = "2",
            }
        },
    };
}
