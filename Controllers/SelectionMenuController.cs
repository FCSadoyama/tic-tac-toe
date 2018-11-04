using System;
using tic_tac_toe.Enumerators;

namespace tic_tac_toe.Controllers
{
    public static class SelectionMenuController
    {
        public static MatchPlayerEnum GetPlayers()
        {
            System.Console.WriteLine("Hello! Welcome to Tic-Tac-Toe.");
            System.Console.WriteLine("Tell me, who's playing?");
            System.Console.WriteLine("[1 - Human vs Computer]");
            System.Console.WriteLine("[2 - Human vs Human]");
            System.Console.WriteLine("[3 - Computer vs Computer]");
            Int32.TryParse(System.Console.ReadLine(), out var playersAsInt);
            System.Console.Clear();
            while (!IsOptionValid(playersAsInt))
            {
                System.Console.WriteLine("Please, give me a valid game option.");
                System.Console.WriteLine("[1 - Human vs Computer]");
                System.Console.WriteLine("[2 - Human vs Human]");
                System.Console.WriteLine("[3 - Computer vs Computer]");
                Int32.TryParse(System.Console.ReadLine(), out playersAsInt);
                System.Console.Clear();
            }

            return (MatchPlayerEnum)playersAsInt;
        }

        public static DifficultyEnum GetDifficulty()
        {
            System.Console.WriteLine("How hard do you want me to be?");
            System.Console.WriteLine("[1 - Easy]");
            System.Console.WriteLine("[2 - Medium]");
            System.Console.WriteLine("[3 - Hard]");
            Int32.TryParse(System.Console.ReadLine(), out var difficultyAsInt);
            System.Console.Clear();
            while (!IsOptionValid(difficultyAsInt))
            {
                System.Console.WriteLine("Please, give me a valid game option.");
                System.Console.WriteLine("[1 - Easy]");
                System.Console.WriteLine("[2 - Medium]");
                System.Console.WriteLine("[3 - Hard]");
                Int32.TryParse(System.Console.ReadLine(), out difficultyAsInt);
                System.Console.Clear();
            }

            return (DifficultyEnum)difficultyAsInt;
        }

        private static bool IsOptionValid(int mode)
        {
            if (mode >= 1 && mode <= 3)
                return true;
            return false;
        }
    }
}