
using GameCatalogue;
namespace trasis_test;
/** 

 * Auto-generated code below aims at helping you parse 

 * the standard input according to the problem statement. 

 **/

class Solution

{
    static void Main(string[] args)
    {
        var game = GameFactory.GetGame();

        try
        {   
            int N = int.Parse(Console.ReadLine());
            game.VerifyNumberOfParticipants(N);

            for (int i = 0; i < N; i++)
            {
                try
                {
                    game.CreatesPlayerFromInput();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occured during the creation of a user: {ex.Message}. Please try again.");
                }
                    
            }

            var winner = game.Play();

            Console.WriteLine("WHO IS THE WINNER?");
            Console.WriteLine($"{winner.Number}");
            Console.WriteLine($"{winner.GameSummary}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured: {ex.Message}");
        }
    }
}


