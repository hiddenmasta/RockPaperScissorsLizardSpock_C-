using FluentAssertions;
namespace RockPaperScissorsLizardSpockGame.Tests;

public class ConsoleGameTests
{
    private static Player RockPlayer = new Player(1, new Rock());
    private static Player SpockPlayer = new Player(2, new Spock());
    private static Player PaperPlayer = new Player(3, new Paper());
    private static Player LizardPlayer = new Player(4, new Lizard());
    private static Player ScissorsPlayer = new Player(5, new Scissors());

    [Fact]
    public void ConsoleGame_VerifyNumberOfParticipants_WithNoPowerOf2()
    {
        var game = new ConsoleGame();
        var action = () => game.VerifyNumberOfParticipants(-1);
        action
            .Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage("The number of participants must be a power of 2");
    }

    [Fact]
    public void ConsoleGame_VerifyNumberOfParticipants_WithOutOfRangeValue()
    {
        var game = new ConsoleGame();
        var action = () => game.VerifyNumberOfParticipants(2048);
        action
            .Should()
            .ThrowExactly<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void ConsoleGame_Play_WithNoPowerOf2PlayersNumber()
    {
        var game = new ConsoleGame();
        var action = game.Play;
        action
            .Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage("The number of participants must be a power of 2");
    }

    [Fact]
    public void ConsoleGame_Play_WithOutOfRangeNumberOfPlayers()
    {
        var game = new ConsoleGame();
        game.AddPlayer(new Player(1, new Rock()));

        var action = game.Play;
        action
            .Should()
            .ThrowExactly<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void ConsoleGame_Play_WithNotUniqueNumber()
    {
        var game = new ConsoleGame();
        game.AddPlayer(new Player(1, new Rock()));
        game.AddPlayer(new Player(1, new Rock()));

        var action = game.Play;
        action
            .Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage("At least one player doesn't have a unique number");
    }

    [Theory]
    [MemberData(nameof(GetPlayers))]
    public void ConsoleGame_Play_PlayersWithBetterComponent_Wins(Player player1, Player player2)
    {
        var game = new ConsoleGame();
        game.AddPlayer(player1);
        game.AddPlayer(player2);

        var winner = game.Play();
        winner.Should().Be(player1);
    }

    [Fact]
    public void ConsoleGame_Play_PlayersWithLowerNumber_Wins_WhenTie()
    {
        var game = new ConsoleGame();
        game.AddPlayer(new Player(1, new Rock()));
        game.AddPlayer(new Player(2, new Rock()));

        var winner = game.Play();
        winner.Number.Should().Be(1);
    }

    public static IEnumerable<object[]> GetPlayers()
    {
        yield return new Player[] { ScissorsPlayer, PaperPlayer };
        yield return new Player[] { PaperPlayer, RockPlayer};
        yield return new Player[] { RockPlayer, LizardPlayer };
        yield return new Player[] { LizardPlayer, SpockPlayer };
        yield return new Player[] { SpockPlayer, ScissorsPlayer };
        yield return new Player[] { ScissorsPlayer, LizardPlayer };
        yield return new Player[] { LizardPlayer, PaperPlayer };
        yield return new Player[] { PaperPlayer, SpockPlayer };
        yield return new Player[] { SpockPlayer, RockPlayer };
        yield return new Player[] { RockPlayer, ScissorsPlayer };
    }

}