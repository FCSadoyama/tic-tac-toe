using tic_tac_toe.enumerators;
using tic_tac_toe.IModels.IBoardLayer;

namespace tic_tac_toe.IModels.IProfileLayer
{
    public interface IComputer
    {
         DifficultyEnum Difficulty { get; set; }

         int EvalBoard(IBoard board);
         int GetBestMove(IBoard board);
         bool MarkBoardCenter(IBoard board);
         bool MoveToWin(IBoard board);
         bool MoveToBlock(IBoard board);
    }
}