using System;
using tic_tac_toe.Models;

namespace tic_tac_toe
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Clear();
            bool loopOnGame = Game.Start();
            while (loopOnGame)
            {
                System.Console.Clear();
                loopOnGame = Game.Start();
            }
        }
    }
}
