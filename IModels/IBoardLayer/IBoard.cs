using tic_tac_toe.Models.BoardLayer;
using tic_tac_toe.Enumerators;

namespace tic_tac_toe.IModels.IBoardLayer
{
    public interface IBoard
    {
        IGrid Grid { get; }
        int Center { get; }

        /// <summary>
        /// Draw the board on screen
        /// </summary>
        void Draw();
        /// <summary>
        /// Marks a position on the board's grid.
        /// </summary>
        /// <param name="position">int</param>
        /// <param name="newMark">MarkEnum</param>
        /// <returns>True or false, depending if the position was available</returns>
        bool MakeMove(int position, MarkEnum newMark);
        /// <summary>
        /// Check if a position on grid isavailable
        /// </summary>
        /// <param name="position">int</param>
        /// <returns>True or false, depending if the position was available</returns>
        bool IsSpotAvailable(int position);
        /// <summary>
        /// Check if the game is over (either a win or a tie)
        /// </summary>
        /// <returns>True or false, depending if the game is over</returns>        
        bool IsGameOver();
        /// <summary>
        /// Return the Mark symbol of the winner
        /// </summary>
        /// <returns>MarkEnum of teh winner</returns>  
        MarkEnum GetWinner();
        /// <summary>
        /// Verifies if the grid is completly marked
        /// </summary>
        /// <returns>True or false</returns>  
        bool IsGridFull();
        /// <summary>
        /// Gets all the lines in the grid in order (H1, H4, H7, V1, V2, V3, D1, D3).
        /// </summary>
        /// <returns>Array of Line object</returns>  
        ILine[] GetAllGridLines();
        /// <summary>
        /// Gets all spots on the grid, ordered by it's position.
        /// </summary>
        /// <returns>Array of Spot object</returns>  
        ISpot[] GetAllGridSpots();
        /// <summary>
        /// Gets the available spots on the grid, ordered by it's position.
        /// </summary>
        /// <returns>Array of Spot object</returns>  
        ISpot[] GetAvailableGridSpots();
    }
}