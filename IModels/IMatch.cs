namespace tic_tac_toe.IModels
{
    public interface IMatch
    {
        /// <summary>
        /// Initializes a new match
        /// </summary>
        /// <returns></returns>
        GameStateEnum Start();
        /// <summary>
        /// Get who's playing and which move this player wanst to make
        /// </summary>
        /// <returns></returns>
        GameStateEnum Play();
        /// <summary>
        /// Check if the game has ended (both on a win and a tie)
        /// </summary>
        /// <returns></returns>
        GameStateEnum CheckMatchOver();
    }
}