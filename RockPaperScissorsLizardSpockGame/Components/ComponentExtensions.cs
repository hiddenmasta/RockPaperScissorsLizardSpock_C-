public static class ComponentExtensions
{
    private static readonly IEnumerable<Component> _components = new List<Component>
    {
        new Rock(),
        new Paper(),
        new Scissors(),
        new Lizard(),
        new Spock()
    };

    public static Component ToComponent(this string str)
    {
        return _components.SingleOrDefault(c => c.ToString() == str) ?? throw new InvalidCastException("The given sign doesn't match any components of the game");
    }
}



