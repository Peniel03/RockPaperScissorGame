
namespace RockPaperScissorGame
{
    public class GameRules
    {
        private readonly List<string> moves;

        public GameRules(List<string> moves)
        {
            this.moves = moves;
        }

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

        public string GetMove(int index)
        {
            return moves[index];
        }
    }
}
