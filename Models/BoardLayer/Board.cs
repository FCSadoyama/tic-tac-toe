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

        public Board(Board board)
        {
            this.Grid = new Grid(board.Grid);
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

        public bool IsGameOver()
        {
            Line[] lines = this.GetAllGridLines();
            foreach(var line in lines)
            {
                if (line.IsVictoryLine(out MarkEnum mark))
                {
                    return true;
                }
            }
            if (this.IsGridFull())
            {
                return true;
            }                

            return false;
        }

        public MarkEnum GetWinner()
        {
            Line[] lines = this.GetAllGridLines();
            foreach(var line in lines)
            {
                if (line.IsVictoryLine(out MarkEnum winnerMark))
                {
                    return winnerMark;
                }
            }
            return MarkEnum.Null;
        }

        public bool IsGridFull()
        {
            return this.Grid.IsFull();
        }

        public Line[] GetAllGridLines()
        {
            return this.Grid.GetAllLines();
        }

        public Spot[] GetAllGridSpots()
        {
            return this.Grid.GetAllSpots();
        }

        public Spot[] GetAvailableGridSpots()
        {
            return this.Grid.GetAvailableSpots();
        }
    }
}