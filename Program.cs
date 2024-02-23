using RockPaperScissorGame;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 3 || args.Length % 2 == 0 || args.Length != args.Distinct().Count())
        {
            Console.WriteLine("Error: Incorrect number of arguments or duplicate moves.");
            Console.WriteLine("Example usage: dotnet run rock paper scissors lizard Spock");
            return;
        }
        PlayGame(args);
    }

    static void PlayGame(string[] moves)
    {
        List<string> movesList = new List<string>(moves);
        byte[] key = KeyGenerator.GenerateKey();
        Random random = new Random();
        GameRules rules = new GameRules(movesList);
        string[,] results = new string[movesList.Count, movesList.Count];

        for (int i = 0; i < movesList.Count; i++)
        {
            for (int j = 0; j < movesList.Count; j++)
            {
                results[i, j] = rules.DetermineWinner(i, j);
            }
        }

        HelpTableGenerator.Render(movesList, results);

        byte[] computerKey = KeyGenerator.GenerateKey();
        int computerMoveIndex = random.Next(movesList.Count);
        string computerMove = rules.GetMove(computerMoveIndex);
        string hmac = HMACGenerator.GenerateHMAC(computerMove, key);

        Console.WriteLine($"HMAC: {hmac}");

        Console.WriteLine("Available moves:");
        for (int i = 0; i < movesList.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {movesList[i]}");
        }
        Console.WriteLine("0 - exit");
        Console.WriteLine("? - help");

        int userMoveIndex = -1;
        do
        {
            Console.Write("Enter your move: ");
            string input = Console.ReadLine(); 

            if (input == "?")
            {
                HelpTableGenerator.Render(movesList, results);
                continue;
            }

            if (!int.TryParse(input, out userMoveIndex) || userMoveIndex < 0 || userMoveIndex > movesList.Count)
            {
                Console.WriteLine("Invalid input. Please enter a valid move or '?' for help.");
                continue;
            }

            if (userMoveIndex == 0)
                return;

            userMoveIndex--; // Adjusting to zero-based index

            string userMove = rules.GetMove(userMoveIndex);
            Console.WriteLine($"Your move: {userMove}");
            Console.WriteLine($"Computer move: {computerMove}");

            string winner = rules.DetermineWinner(userMoveIndex, computerMoveIndex);
            if (winner == "User")
                Console.WriteLine("You win!");
            else if (winner == "Computer")
                Console.WriteLine("Computer win!");
            else
                Console.WriteLine("It's a draw!");

            Console.WriteLine($"HMAC key: {BitConverter.ToString(computerKey).Replace("-", "")}");

        } while (userMoveIndex != 0);
    }
}