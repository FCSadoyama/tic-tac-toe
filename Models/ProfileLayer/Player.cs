using System;
using tic_tac_toe.Enumerators;
using tic_tac_toe.IModels.IProfileLayer;

namespace tic_tac_toe.Models.ProfileLayer
{
    public class Player : IPlayer
    {
        public string Name {get; protected set;}
        public MarkEnum Mark {get; protected set;}

        protected MarkEnum GetEnemyMark()
        {
            if (this.Mark == MarkEnum.X)
                return MarkEnum.O;
            return MarkEnum.X;
        }

        protected MarkEnum SwitchMark(MarkEnum mark)
        {
            return mark == this.Mark ? this.GetEnemyMark():this.Mark;
        }
    }
}