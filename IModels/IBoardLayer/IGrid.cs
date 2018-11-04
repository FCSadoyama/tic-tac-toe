using tic_tac_toe.Models.BoardLayer;

namespace tic_tac_toe.IModels.IBoardLayer
{
    public interface IGrid
    {
         ILine GetFirstHorizontalLine();
         ILine GetSecondHorizontalLine();
         ILine GetThirdHorizontalLine();

         ILine GetFirstVerticalLine();
         ILine GetSecondVerticalLine();
         ILine GetThirdVerticalLine();

         ILine GetMainDiagonal();
         ILine GetAntiDiagonal();

         ILine[] GetAllLines();
         ISpot[] GetAllSpots();

         ISpot[] GetAvailableSpots();

         bool Contains(MarkEnum mark);
         bool IsFull();
    }
}