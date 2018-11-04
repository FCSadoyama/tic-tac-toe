using tic_tac_toe.Models.BoardLayer;

namespace tic_tac_toe.IModels.IBoardLayer
{
    public interface ILine
    {
         ISpot Spot0 { get; }
         ISpot Spot1 { get; }
         ISpot Spot2 { get; }

         bool IsVictoryLine(out MarkEnum mark);
         bool IsPossibleVictoryLine(MarkEnum mark);
         int GetPossibleWinPosition(MarkEnum mark);
         bool Contains(MarkEnum mark);
    }
}