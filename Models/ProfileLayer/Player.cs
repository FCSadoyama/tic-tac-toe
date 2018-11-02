using System;
using tic_tac_toe.IModels.IProfileLayer;

namespace tic_tac_toe.Models.ProfileLayer
{
    public class Player
    {
        public string Name {get; protected set;}
        public MarkEnum Mark {get; protected set;}

        protected MarkEnum GetEnemyMark()
        {
            if (this.Mark == MarkEnum.X)
                return MarkEnum.O;
            return MarkEnum.X;
        }
    }
}