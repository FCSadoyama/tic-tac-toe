using System;
using System.Linq;
using tic_tac_toe.IModels.IBoardLayer;

namespace tic_tac_toe.Models.BoardLayer
{
    public class Board
    {
        public IGrid Grid { get; protected set; }
        public readonly int Center = 5;

        public Board()
        {
            Grid = new Grid();
        }

        public void Draw()
        {
            System.Console.WriteLine("Board:");
            Line line = this.Grid.GetFirstHorizontalLine();
            System.Console.WriteLine("{0}#{1}#{2}", line.Spot0.ToString(), line.Spot1.ToString(), line.Spot2.ToString());
            System.Console.WriteLine("#####");
            line = this.Grid.GetSecondHorizontalLine();
            System.Console.WriteLine("{0}#{1}#{2}", line.Spot0.ToString(), line.Spot1.ToString(), line.Spot2.ToString());
            System.Console.WriteLine("#####");
            line = this.Grid.GetThirdHorizontalLine();
            System.Console.WriteLine("{0}#{1}#{2}", line.Spot0.ToString(), line.Spot1.ToString(), line.Spot2.ToString());
            System.Console.WriteLine(string.Empty);
        }

        public bool MakeMove(int position, MarkEnum newMark)
        {
            Spot[] lines = Grid.GetAllSpots();
            return this.Grid.GetAllSpots()[position - 1].ChangeMark(newMark);
        }

        public bool IsSpotAvailable(int position)
        {
            Spot[] lines = Grid.GetAllSpots();
            return lines[position - 1].IsMarkEmpty();
        }

        public bool IsGameOver(out MarkEnum mark)
        {
            Line[] lines = this.GetAllGridLines();
            mark = MarkEnum.Null;
            foreach(var line in lines)
            {
                if (line.IsVictoryLine(out mark))
                {
                    return true;
                }
            }
            if (this.IsGridFull())
            {
                mark = MarkEnum.Null;
                return true;
            }                

            return false;
        }

        public bool IsGridFull()
        {
            return this.Grid.IsFull();
        }

        public Line[] GetAllGridLines()
        {
            return Grid.GetAllLines();
        }

        public Spot[] GetAllGridSpots()
        {
            return Grid.GetAllSpots();
        }
    }
}