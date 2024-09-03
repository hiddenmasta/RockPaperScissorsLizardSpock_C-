namespace RockPaperScissorsLizardSpockGame;

public class ConsoleGame : IConsoleGame
{
    private const int MIN_VALUE_POWER_OF_2 = 1;
    private const int MAX_VALUE_POWER_OF_2 = 10;
    private double _minValue = Math.Pow(2, MIN_VALUE_POWER_OF_2);
    private double _maxValue = Math.Pow(2, MAX_VALUE_POWER_OF_2);
    private const string playerGameSummaryCharacterToAppend = " ";
    private readonly List<(Type, Type)> _rules = new();
    private List<Player> _players = new();

    public ConsoleGame()
    {
        BuildRules();
    }

    private static bool IsPowerOfTwo(uint x)
    {
        return (x != 0) && ((x & (x - 1)) == 0);
    }

    private void BuildRules()
    {
        _rules.Add((typeof(Scissors), typeof(Paper)));
        _rules.Add((typeof(Paper), typeof(Rock)));
        _rules.Add((typeof(Rock), typeof(Lizard)));
        _rules.Add((typeof(Lizard), typeof(Spock)));
        _rules.Add((typeof(Spock), typeof(Scissors)));
        _rules.Add((typeof(Scissors), typeof(Lizard)));
        _rules.Add((typeof(Lizard), typeof(Paper)));
        _rules.Add((typeof(Paper), typeof(Spock)));
        _rules.Add((typeof(Spock), typeof(Rock)));
        _rules.Add((typeof(Rock), typeof(Scissors)));
    }

    public IPlayer Play()
    {
        VerifyRequirements(_players);
        var playersLeft = new Stack<Player>(_players);
        var winners = new Stack<Player>();

        do
        {
            winners.Clear();

            while (playersLeft.Count >= 2)
            {
                var round = PlayRound(playersLeft.Pop(), playersLeft.Pop());
                round.Winner.GameSummary.Append(round.Looser + playerGameSummaryCharacterToAppend);
                round.Looser.GameSummary.Append(round.Winner + playerGameSummaryCharacterToAppend);
                winners.Push(round.Winner);
            }

            if (winners.Count >= 2)
            {
                var winnersCount = winners.Count();
                for (var i = 0; i < winnersCount; i++)
                    playersLeft.Push(winners.Pop());
            }


        } while (winners.Count != 1);

        return winners.ElementAt(0);
    }

    private void VerifyRequirements(IEnumerable<IPlayer> players)
    {
        VerifyNumberOfParticipants(players.Count());
        if (players.DistinctBy(p => p.Number).Count() != players.Count()) throw new ArgumentException("At least one player doesn't have a unique number");
    }

    private (Player Winner, Player Looser) PlayRound(Player player1, Player player2)
    {
        if (player1.Sign == player2.Sign) return player1.Number > player2.Number ? (player2, player1) : (player1, player2);

        var firstPlayerRules = _rules.Where(r => r.Item1 == player1.Sign.GetType());
        var rulesWherePlayer2Loses = firstPlayerRules.Where(r => r.Item2 == player2.Sign.GetType());

        if (rulesWherePlayer2Loses.Any())
            return (player1, player2);
        else
            return (player2, player1);
    }

    public void VerifyNumberOfParticipants(int numberOfParticipants)
    {
        if (!IsPowerOfTwo((uint)numberOfParticipants)) throw new ArgumentException("The number of participants must be a power of 2");

        if (numberOfParticipants < _minValue || numberOfParticipants > _maxValue)
            throw new ArgumentOutOfRangeException($"The number of participants must be in the following range : {_minValue}<=N<={_maxValue}");
    }

    void IConsoleGame.CreatesPlayerFromInput()
    {
        string[] inputs = Console.ReadLine().Split(" ");
        int playerNumber = int.Parse(inputs[0]);
        var playerSign = inputs[1].ToComponent();
        _players.Add(new Player(playerNumber, playerSign));
    }

    public void AddPlayer(Player player)
    {
        _players.Add(player);
    }
}