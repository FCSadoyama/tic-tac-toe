namespace tic_tac_toe.IModels
{
    public interface IMatch
    {
         GameStateEnum Start();
         GameStateEnum Play();
         GameStateEnum CheckMatchOver();
    }
}