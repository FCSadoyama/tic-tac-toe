using tic_tac_toe.Enumerators;

namespace tic_tac_toe.IModels.IBoardLayer
{
    public interface ISpot
    {
        MarkEnum Type { get; }
        int Position { get; }

        /// <summary>
        /// Change the MarkEnum Type
        /// </summary>
        /// <param name="mark">MarkEnum</param>
        /// <returns>True or false</returns>
        bool ChangeMark(MarkEnum newMark);
        /// <summary>
        /// Verifies if the Spot object is available
        /// </summary>
        /// <returns>True or false</returns>
        bool IsMarkEmpty();
        /// <summary>
        /// Returns the output of the spot, based whether it was marked or not
        /// </summary>
        /// <returns>It's type or it's position</returns>
        string ToString();
    }
}