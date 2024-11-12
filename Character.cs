namespace TwistyRoad;
internal class Character
{
    private int _health;

    public CharacterClass Class { get; set; }

    public string Name { get; set; }

    public int Attack { get; set; }

    public int Defence { get; set; }

    public int Health
    {
        get { return _health; }
        set
        {
            if (value > MaxHealth)
            {
                _health = MaxHealth;
            }
            else
            {
                _health = value;
            }
        }
    }

    public int MaxHealth { get; set; }

    public void RestoreHealth()
    {
        _health = MaxHealth;
    }
}

