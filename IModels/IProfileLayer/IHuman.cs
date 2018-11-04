namespace tic_tac_toe.IModels.IProfileLayer
{
    public interface IHuman
    {
        /// <summary>
        /// Gets the human player imput for a move
        /// </summary>
        /// <param name="isAvailable">bool</param>
        /// <returns>Returns the desired position</returns>
        int GetSpot(bool isAvailable = true);
    }
}