using tic_tac_toe.Models.BoardLayer;

namespace tic_tac_toe.IModels.IBoardLayer
{
    public interface IGrid
    {
         Line GetFirstHorizontalLine();
         Line GetSecondHorizontalLine();
         Line GetThirdHorizontalLine();

         Line GetFirstVerticalLine();
         Line GetSecondVerticalLine();
         Line GetThirdVerticalLine();

         Line GetMainDiagonal();
         Line GetAntiDiagonal();

         Line[] GetAllLines();
         Spot[] GetAllSpots();

        Spot[] GetAvailableSpots();

         bool Contains(MarkEnum mark);
         bool IsFull();
    }
}