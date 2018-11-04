using tic_tac_toe.Enumerators;
using tic_tac_toe.IModels.IBoardLayer;

namespace tic_tac_toe.IModels.IProfileLayer
{
    public interface IComputer
    {
        DifficultyEnum Difficulty { get; set; }

        /// <summary>
        /// Initiates the AI and searches for teh best possible move
        /// </summary>
        /// <param name="board">IBoard</param>
        /// <returns>Returns the position of teh best play</returns>
        int EvalBoard(IBoard board);
        /// <summary>
        /// Gets the best possible move
        /// </summary>
        /// <param name="board">IBoard</param>
        /// <returns>Returns the position of teh best play</returns>
        int GetBestMove(IBoard board);
        /// <summary>
        /// Tries to mark the center of the board
        /// </summary>
        /// <param name="board">IBoard</param>
        /// <returns>True or false</returns>
        bool MarkBoardCenter(IBoard board);
        /// <summary>
        /// Gets the position of a possible victory move
        /// </summary>
        /// <param name="board">IBoard</param>
        /// <returns>True or false</returns>
        bool MoveToWin(IBoard board);
        /// <summary>
        /// Gets the position of a possible loss move
        /// </summary>
        /// <param name="board">IBoard</param>
        /// <returns>True or false</returns>
        bool MoveToBlock(IBoard board);
    }
}