using System.Collections.Generic;
using tic_tac_toe.enumerators;
using tic_tac_toe.IModels.IBoardLayer;

namespace tic_tac_toe.Models.BoardLayer
{
    public class Grid : IGrid
    {
        private Line _horizontal0;
        private Line _horizontal1;
        private Line _horizontal2;

        public Grid()
        {
            _horizontal0 = new Line(1, 2, 3);

            _horizontal1 = new Line(4, 5, 6);

            _horizontal2 = new Line(7, 8, 9);
        }

        public Line GetFirstHorizontalLine()
        {
            return _horizontal0;
        }

        public Line GetSecondHorizontalLine()
        {
            return _horizontal1;
        }

        public Line GetThirdHorizontalLine()
        {
            return _horizontal2;
        }

        public Line GetFirstVerticalLine()
        {
            Line line = new Line(this._horizontal0.Spot0, this._horizontal1.Spot0, this._horizontal2.Spot0);

            return line;
        }

        public Line GetSecondVerticalLine()
        {
            Line line = new Line(this._horizontal0.Spot1, this._horizontal1.Spot1, this._horizontal2.Spot1);

            return line;
        }

        public Line GetThirdVerticalLine()
        {
            Line line = new Line(this._horizontal0.Spot2, this._horizontal1.Spot2, this._horizontal2.Spot2);

            return line;
        }

        public Line GetMainDiagonal()
        {
            Line line = new Line(this._horizontal0.Spot0, this._horizontal1.Spot1, this._horizontal2.Spot2);

            return line;
        }

        public Line GetAntiDiagonal()
        {
            Line line = new Line(this._horizontal0.Spot2, this._horizontal1.Spot1, this._horizontal2.Spot0);

            return line;
        }

        public Line[] GetAllLines()
        {
            Line[] lines = new Line[]
            {
                GetFirstHorizontalLine(), GetSecondHorizontalLine(), GetThirdHorizontalLine(),
                GetFirstVerticalLine(), GetSecondVerticalLine(), GetThirdVerticalLine(),
                GetMainDiagonal(), GetAntiDiagonal()
            };

            return lines;
        }

        public Spot[] GetAllSpots()
        {
            Spot[] spots = new Spot[9];
            Line line = GetFirstHorizontalLine();
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