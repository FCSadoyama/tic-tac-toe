using System;
using tic_tac_toe.Enumerators;

namespace tic_tac_toe.IModels.IProfileLayer
{
    public interface IPlayer
    {
        string Name { get; }
        MarkEnum Mark { get; }
    }
}