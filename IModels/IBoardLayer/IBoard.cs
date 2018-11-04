using tic_tac_toe.Models.BoardLayer;

namespace tic_tac_toe.IModels.IBoardLayer
{
    public interface IBoard
    {
         IGrid Grid { get; }
         int Center { get; }

         void Draw();
         bool MakeMove(int position, MarkEnum newMark);
         bool IsSpotAvailable(int position);
         bool IsGameOver();
         MarkEnum GetWinner();
         bool IsGridFull();
         ILine[] GetAllGridLines();
         ISpot[] GetAllGridSpots();
         ISpot[] GetAvailableGridSpots();
    }
}