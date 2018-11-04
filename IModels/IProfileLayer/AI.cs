using System.Collections.Generic;
using tic_tac_toe.enumerators;
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

        abstract protected int GetScore(IBoard board, int depth = 0);
        abstract protected int Minimax(IBoard board, MarkEnum player, DifficultyEnum difficulty, int depth = 0);
        abstract protected void GetMiniMaxPlay(IBoard board, DifficultyEnum difficulty);
        abstract protected bool FindWinOrBlockLine(IBoard board, MarkEnum mark);
        abstract protected void MakeRandomMove(IBoard board);
        abstract protected int GetGoodMove(IList<int> scores, IList<int> moves);
    }
}