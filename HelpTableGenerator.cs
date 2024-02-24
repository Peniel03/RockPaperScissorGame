using ConsoleTables;

namespace RockPaperScissorGame
{ 
    /// <summary>
    /// The Help table generator class help to generate a table using the ConsoleTables library
    /// </summary>
    public class HelpTableGenerator
    {
        /// <summary>
        /// This method places the table header and ensure that the table will remains stable 
        /// with any number of additional rows and columns
        /// </summary>
        /// <param name="moves"></param>
        /// <param name="results"></param>
        public static void Render(List<string> moves, string[,] results)
        {
            int n = moves.Count;
            var table = new ConsoleTable("v PC\\User >");
            table.AddColumn(moves.ToArray());

            for (int i = 0; i < n; i++)
            {
                var row = new string[n + 1];
                row[0] = moves[i];
                for (int j = 0; j < n; j++)
                {
                    row[j + 1] = results[i, j];
                }
                table.AddRow(row);
            }
            Console.WriteLine("Help Table:");
            table.Write();
        }
    }
}
