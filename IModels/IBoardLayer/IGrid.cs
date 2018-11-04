using tic_tac_toe.Models.BoardLayer;
using tic_tac_toe.Enumerators;

namespace tic_tac_toe.IModels.IBoardLayer
{
    public interface IGrid
    {
        /// <summary>
        /// Get a specific Line object of Grid object (H1)
        /// </summary>
        /// <returns>Line object</returns>  
        ILine GetFirstHorizontalLine();
        /// <summary>
        /// Get a specific Line object of Grid object (H4)
        /// </summary>
        /// <returns>Line object</returns> 
        ILine GetSecondHorizontalLine();
        /// <summary>
        /// Get a specific Line object of Grid object (H7)
        /// </summary>
        /// <returns>Line object</returns> 
        ILine GetThirdHorizontalLine();

        /// <summary>
        /// Get a specific Line object of Grid object (V1)
        /// </summary>
        /// <returns>Line object</returns> 
        ILine GetFirstVerticalLine();
        /// <summary>
        /// Get a specific Line object of Grid object (V2)
        /// </summary>
        /// <returns>Line object</returns> 
        ILine GetSecondVerticalLine();
        /// <summary>
        /// Get a specific Line object of Grid object (V3)
        /// </summary>
        /// <returns>Line object</returns> 
        ILine GetThirdVerticalLine();

        /// <summary>
        /// Get a specific Line object of Grid object (D1)
        /// </summary>
        /// <returns>Line object</returns> 
        ILine GetMainDiagonal();
        /// <summary>
        /// Get a specific Line object of Grid object (D3)
        /// </summary>
        /// <returns>Line object</returns> 
        ILine GetAntiDiagonal();

        /// <summary>
        /// Gets all the lines in the grid in order (H1, H4, H7, V1, V2, V3, D1, D3).
        /// </summary>
        /// <returns>Array of Line object</returns>  
        ILine[] GetAllLines();
        /// <summary>
        /// Gets all spots on the grid, ordered by it's position.
        /// </summary>
        /// <returns>Array of Spot object</returns>  
        ISpot[] GetAllSpots();

        /// <summary>
        /// Gets the available spots on the grid, ordered by it's position.
        /// </summary>
        /// <returns>Array of Spot object</returns> 
        ISpot[] GetAvailableSpots();

        /// <summary>
        /// Verifies if the Grid contains a specific Mark
        /// </summary>
        /// <param name="mark">MarkEnum</param>
        /// <returns>True or false, depending if the position was available</returns>
        bool Contains(MarkEnum mark);
        /// <summary>
        /// Verifies if the Grid is full
        /// </summary>
        /// <returns>True or false, depending if the grid is full</returns>
        bool IsFull();
    }
}