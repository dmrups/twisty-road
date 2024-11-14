using System.Globalization;

namespace TwistyRoad.Scenarious;
internal class Leaf
{
    public string Text { get; set; }

    public Action<Character> CharacterAction { get; set; }

    public Func<Character, string> TextAction { get; set; }

    public string ExitOption { get; set; }

    public bool DialogExit { get; set; }
}
