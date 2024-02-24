namespace RockPaperScissorGame
{
    /// <summary>
    /// This class set the rules of the game 
    /// </summary>
    public class GameRules
    {
        private readonly List<string> moves;

        /// <summary>
        /// Initialize a new instance of <see cref="GameRules"/>
        /// </summary>
        /// <param name="moves">The passed move </param>
        public GameRules(List<string> moves)
        {
            this.moves = moves;
        }

        /// <summary>
        /// Function to determine the winner of the game
        /// </summary>
        /// <param name="userMoveIndex">The index of the user's move</param>
        /// <param name="computerMoveIndex">The index of the computer move</param>
        /// <returns></returns>
        public string DetermineWinner(int userMoveIndex, int computerMoveIndex)
        {
            int halfMoves = moves.Count / 2;
            int diff = (computerMoveIndex - userMoveIndex + moves.Count) % moves.Count;

            if (diff == 0)
                return "Draw";
            else if (diff <= halfMoves)
                return "Computer";
            else
                return "User";
        }

        /// <summary>
        /// Function to get the move by index
        /// </summary>
        /// <param name="index">the move's index</param>
        /// <returns></returns>
        public string GetMove(int index)
        {
            return moves[index];
        }
    }
}
