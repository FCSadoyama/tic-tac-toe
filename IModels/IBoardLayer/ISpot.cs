namespace tic_tac_toe.IModels.IBoardLayer
{
    public interface ISpot
    {
         MarkEnum Type { get; }
         int Position { get; }

         bool ChangeMark(MarkEnum newMark);
         bool IsMarkEmpty();
         string ToString();
    }
}