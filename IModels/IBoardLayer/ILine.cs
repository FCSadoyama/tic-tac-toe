using tic_tac_toe.Models.BoardLayer;
using tic_tac_toe.Enumerators;

namespace tic_tac_toe.IModels.IBoardLayer
{
    public interface ILine
    {
        ISpot Spot0 { get; }
        ISpot Spot1 { get; }
        ISpot Spot2 { get; }

        /// <summary>
        /// Verifies if the Line object has 3 of the same Mark.
        /// </summary>
        /// <param name="mark">out MarkEnum</param>
        /// <returns>True or false, out mark</returns>
        bool IsVictoryLine(out MarkEnum mark);
        /// <summary>
        /// Verifies if the Line object contais 2 of the same Marks and a empty position
        /// </summary>
        /// <param name="mark">MarkEnum</param>
        /// <returns>True or false</returns>
        bool IsPossibleVictoryLine(MarkEnum mark);
        /// <summary>
        /// Gets the empty position of a possible victory line
        /// </summary>
        /// <param name="mark">MarkEnum</param>
        /// <returns>True or false</returns>
        int GetPossibleWinPosition(MarkEnum mark);
        /// <summary>
        /// Verifies if the Line contains a specific Mark
        /// </summary>
        /// <param name="mark">MarkEnum</param>
        /// <returns>True or false</returns>
        bool Contains(MarkEnum mark);
    }
}