using System.Collections.Generic;
using tic_tac_toe.Enumerators;
using tic_tac_toe.IModels.IBoardLayer;
using tic_tac_toe.Models.ProfileLayer;

namespace tic_tac_toe.IModels.IProfileLayer
{
    public abstract class AI : Player
    {
        protected readonly int MaxPlay = 100;
        protected readonly int MinPlay = -100;
        protected readonly int TiePlay = 0;
        abstract protected int BestMove { get; set; }

        /// <summary>
        /// Calculate the score based on Minimax Algorithm
        /// </summary>
        /// <param name="board">IBoard</param>
        /// <param name="depth">int</param>
        /// <returns>Returns it's score (int)</returns>
        abstract protected int GetScore(IBoard board, int depth = 0);
        /// <summary>
        /// Minimax Algorithm
        /// </summary>
        /// <param name="board">IBoard</param>
        /// <param name="player">MarkEnum</param>
        /// <param name="difficulty">DifficultyEnum</param>
        /// <param name="depth">int</param>
        /// <returns>Returns it's score (int)</returns>
        abstract protected int Minimax(IBoard board, MarkEnum player, DifficultyEnum difficulty, int depth = 0);
        /// <summary>
        /// Calls the Minimax Algorithm
        /// </summary>
        /// <param name="board">IBoard</param>
        /// <param name="difficulty">DifficultyEnum</param>
        abstract protected void GetMiniMaxPlay(IBoard board, DifficultyEnum difficulty);
        /// <summary>
        /// Searches for a possible win or lose
        /// </summary>
        /// <param name="board">IBoard</param>
        /// <param name="mark">MarkEnum</param>
        /// <returns>True or false</returns>
        abstract protected bool FindWinOrBlockLine(IBoard board, MarkEnum mark);
        /// <summary>
        /// Gets a good move, but not the best
        /// </summary>
        /// <param name="scores">IList: int</param>
        /// <param name="moves">IList: int</param>
        /// <returns>Retruns a position (int)</returns>
        abstract protected int GetGoodMove(IList<int> scores, IList<int> moves, DifficultyEnum difficulty);
    }
}