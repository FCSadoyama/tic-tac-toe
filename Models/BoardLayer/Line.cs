using System.Collections.Generic;

namespace tic_tac_toe.Models.BoardLayer
{
    public class Line
    {
        public Spot Spot0 { get; private set; }
        public Spot Spot1 { get; private set; }
        public Spot Spot2 { get; private set; }

        public Line(int FirstSpotValue, int SecondSpotValue, int ThirdSpotValue)
        {
            Spot0 = new Spot(FirstSpotValue);
            Spot1 = new Spot(SecondSpotValue);
            Spot2 = new Spot(ThirdSpotValue);
        }

        public Line(Spot FirstSpot, Spot SecondSpot, Spot ThirdSpot)
        {
            Spot0 = new Spot(FirstSpot);
            Spot1 = new Spot(SecondSpot);
            Spot2 = new Spot(ThirdSpot);
        }

        public bool IsVictoryLine(out MarkEnum mark)
        {
            mark = MarkEnum.Null;
            if ((Spot0.Type == Spot1.Type && Spot1.Type == Spot2.Type) && Spot0.Type != MarkEnum.Null)
            {
                mark = Spot0.Type;
                return true;
            }
            return false;
        }

        public bool IsPossibleVictoryLine(MarkEnum mark)
        {
            if (Spot0.Type == mark && Spot1.Type == mark && Spot2.Type == MarkEnum.Null)
                return true;
            if (Spot0.Type == mark && Spot1.Type == MarkEnum.Null && Spot2.Type == mark)
                return true;
            if (Spot0.Type == MarkEnum.Null && Spot1.Type == mark && Spot2.Type == mark)
                return true;
            return false;
        }

        public int GetPossibleWinPosition(MarkEnum mark)
        {
            if (Spot0.Type == mark && Spot1.Type == mark && Spot2.Type == MarkEnum.Null)
                return Spot2.Position;
            if (Spot0.Type == mark && Spot1.Type == MarkEnum.Null && Spot2.Type == mark)
                return Spot1.Position;
            return Spot0.Position;
        }

        public bool Contains(MarkEnum mark)
        {
            return Spot0.Type == mark || Spot1.Type == mark || Spot2.Type == mark;
        }
    }
}