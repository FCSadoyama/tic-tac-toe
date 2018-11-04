using System;
using tic_tac_toe.Controllers.ProfileLayer;
using tic_tac_toe.IModels.IProfileLayer;
using tic_tac_toe.Enumerators;

namespace tic_tac_toe.Models.ProfileLayer
{
    public class Human : Player, IHuman
    {
        public Human(string name, MarkEnum mark)
        {
            this.Name = name;
            this.Mark = mark;
        }

        public int GetSpot(bool isAvailable = true)
        {
            return HumanController.GetSpot(isAvailable, this.Mark);
        }
    }
}