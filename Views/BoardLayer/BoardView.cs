using tic_tac_toe.IModels.IBoardLayer;
using tic_tac_toe.Models.BoardLayer;

namespace tic_tac_toe.Views.BoardLayer
{
    public static class BoardView
    {
        public static void Draw(IGrid grid)
        {
            System.Console.WriteLine("Board:");
            ILine line = grid.GetFirstHorizontalLine();
            System.Console.WriteLine("{0}#{1}#{2}", line.Spot0.ToString(), line.Spot1.ToString(), line.Spot2.ToString());
            System.Console.WriteLine("#####");
            line = grid.GetSecondHorizontalLine();
            System.Console.WriteLine("{0}#{1}#{2}", line.Spot0.ToString(), line.Spot1.ToString(), line.Spot2.ToString());
            System.Console.WriteLine("#####");
            line = grid.GetThirdHorizontalLine();
            System.Console.WriteLine("{0}#{1}#{2}", line.Spot0.ToString(), line.Spot1.ToString(), line.Spot2.ToString());
            System.Console.WriteLine(string.Empty);
        }
    }
}