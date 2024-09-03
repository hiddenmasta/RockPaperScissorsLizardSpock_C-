using System.Text;

public class Player : IPlayer
{
    public Component Sign { get; private set; }
    public int Number { get; }

    public StringBuilder GameSummary { get; }

    public Player(int number, Component sign)
    {


        Number = number;
        Sign = sign;
        GameSummary = new();
    }

    public override string ToString() => Number.ToString();
}