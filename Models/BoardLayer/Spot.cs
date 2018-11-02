using System;

namespace tic_tac_toe.Models.BoardLayer
{
    public class Spot
    {
        public MarkEnum Type { get; internal set; }
        public int Position { get; internal set; }

        public Spot(int position)
        {
            this.Type = MarkEnum.Null;
            this.Position = position;
        }

        public Spot(Spot newSpot)
        {
            this.Type = newSpot.Type;
            this.Position = newSpot.Position;
        }

        public bool ChangeMark(MarkEnum newMark)
        {
            if (!IsMarkEmpty())
                return false;
            
            this.Type = newMark;
            return true;
        }

        public bool IsMarkEmpty()
        {
            if (this.Type.Equals(MarkEnum.Null))
                return true;
            return false;
        }

        public override string ToString()
        {
            if (this.Type != MarkEnum.Null)
                return this.Type.ToString();
            return this.Position.ToString();
        }
    }
}