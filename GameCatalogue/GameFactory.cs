using RockPaperScissorsLizardSpockGame;
namespace GameCatalogue;

public static class GameFactory
{
    public static IConsoleGame GetGame()
    {
        return new ConsoleGame();
    }
}

