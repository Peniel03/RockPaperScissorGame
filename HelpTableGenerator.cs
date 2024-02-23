using ConsoleTables;
using PowerArgs;
using System.Collections.Generic;


namespace RockPaperScissorGame
{ 
    public class HelpTableGenerator
    {
        public static void Render(List<string> moves, string[,] results)
        {
            int n = moves.Count;
            // Get the maximum length of moves for padding
            int maxMoveLength = 0;
            foreach (string move in moves)
            {
                maxMoveLength = Math.Max(maxMoveLength, move.Length);
            }
            Console.WriteLine("Help Table:");
            Console.Write("+-------------+");
            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('-', maxMoveLength + 2) + "+");
            }
            Console.WriteLine();

            Console.Write("| v PC\\User > |");
            for (int i = 0; i < n; i++)
            {
                Console.Write($" {moves[i].PadLeft(maxMoveLength)} |");
            }
            Console.WriteLine();
            // Print the separator row
            Console.Write("+--------------+");
            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('-', maxMoveLength + 2) + "+");
            }
            Console.WriteLine();

            // Print the data rows
            for (int i = 0; i < n; i++)
            {
                Console.Write($"| {moves[i].PadLeft(12)} |");
                for (int j = 0; j < n; j++)
                {
                    Console.Write($" {results[i, j],-4} |");
                }
                Console.WriteLine();
            }

            // Print the bottom border
            Console.Write("+--------------+");
            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('-', maxMoveLength + 2) + "+");
            }
            Console.WriteLine();
        }
    }
}
