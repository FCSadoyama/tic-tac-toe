using System;
using tic_tac_toe.Console.ProfileLayer;

namespace tic_tac_toe.Models.ProfileLayer
{
    public class Human : Player
    {
        public Human(string name, MarkEnum mark)
        {
            this.Name = name;
            this.Mark = mark;
        }

        public int GetSpot(bool isAvailable = true)
        {
            return HumanInteraction.GetSpotFromHuman(isAvailable, this.Mark);
        }
    }
}