using System.Collections.Generic;
using System.Linq;
using tic_tac_toe.Enumerators;
using tic_tac_toe.IModels.IBoardLayer;

namespace tic_tac_toe.Models.BoardLayer
{
    public class Grid : IGrid
    {
        private ILine _horizontal0;
        private ILine _horizontal1;
        private ILine _horizontal2;

        public Grid()
        {
            _horizontal0 = new Line(1, 2, 3);

            _horizontal1 = new Line(4, 5, 6);

            _horizontal2 = new Line(7, 8, 9);
        }

        public Grid(IGrid grid)
        {
            ILine newHorizontal0 = grid.GetFirstHorizontalLine();
            _horizontal0 = new Line(newHorizontal0.Spot0, newHorizontal0.Spot1, newHorizontal0.Spot2);

            ILine newHorizontal1 = grid.GetSecondHorizontalLine();
            _horizontal1 = new Line(newHorizontal1.Spot0, newHorizontal1.Spot1, newHorizontal1.Spot2);

            ILine newHorizontal2 = grid.GetThirdHorizontalLine();
            _horizontal2 = new Line(newHorizontal2.Spot0, newHorizontal2.Spot1, newHorizontal2.Spot2);
        }

        public ILine GetFirstHorizontalLine()
        {
            return _horizontal0;
        }

        public ILine GetSecondHorizontalLine()
        {
            return _horizontal1;
        }

        public ILine GetThirdHorizontalLine()
        {
            return _horizontal2;
        }

        public ILine GetFirstVerticalLine()
        {
            ILine line = new Line(this._horizontal0.Spot0, this._horizontal1.Spot0, this._horizontal2.Spot0);

            return line;
        }

        public ILine GetSecondVerticalLine()
        {
            ILine line = new Line(this._horizontal0.Spot1, this._horizontal1.Spot1, this._horizontal2.Spot1);

            return line;
        }

        public ILine GetThirdVerticalLine()
        {
            ILine line = new Line(this._horizontal0.Spot2, this._horizontal1.Spot2, this._horizontal2.Spot2);

            return line;
        }

        public ILine GetMainDiagonal()
        {
            ILine line = new Line(this._horizontal0.Spot0, this._horizontal1.Spot1, this._horizontal2.Spot2);

            return line;
        }

        public ILine GetAntiDiagonal()
        {
            ILine line = new Line(this._horizontal0.Spot2, this._horizontal1.Spot1, this._horizontal2.Spot0);

            return line;
        }

        public ILine[] GetAllLines()
        {
            ILine[] lines = new ILine[]
            {
                GetFirstHorizontalLine(), GetSecondHorizontalLine(), GetThirdHorizontalLine(),
                GetFirstVerticalLine(), GetSecondVerticalLine(), GetThirdVerticalLine(),
                GetMainDiagonal(), GetAntiDiagonal()
            };

            return lines;
        }

        public ISpot[] GetAllSpots()
        {
            ISpot[] spots = new Spot[9];
            ILine line = GetFirstHorizontalLine();
            spots[0] = line.Spot0;
            spots[1] = line.Spot1;
            spots[2] = line.Spot2;

            line = GetSecondHorizontalLine();
            spots[3] = line.Spot0;
            spots[4] = line.Spot1;
            spots[5] = line.Spot2;

            line = GetThirdHorizontalLine();
            spots[6] = line.Spot0;
            spots[7] = line.Spot1;
            spots[8] = line.Spot2;

            return spots;
        }

        public ISpot[] GetAvailableSpots()
        {
            ISpot[] availableSpots = this.GetAllSpots()
                                        .GroupBy(x => x.Type)
                                        .ToDictionary(g => g.Key, g => g.ToList())[MarkEnum.Null]
                                        .ToArray();

            return availableSpots;
        }

        public bool Contains(MarkEnum mark)
        {
            return _horizontal0.Contains(mark) || _horizontal1.Contains(mark) || _horizontal2.Contains(mark);
        }

        public bool IsFull()
        {
            return !_horizontal0.Contains(MarkEnum.Null) && !_horizontal1.Contains(MarkEnum.Null) && !_horizontal2.Contains(MarkEnum.Null);
        }
    }
}