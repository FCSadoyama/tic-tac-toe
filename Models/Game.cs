using System;
using tic_tac_toe.IModels;
using tic_tac_toe.Models.ProfileLayer;

namespace tic_tac_toe.Models
{
    public static class Game
    {
        public static GameStateEnum GameState { get; internal set; }
        private static IMatch _newMatch;

        public static bool Start()
        {
            Initialize();
            OnRun();
            return Close(); 
        }

        public static void Initialize()
        {
            GameState = GameStateEnum.OnMenu;
            _newMatch = SelectionMenu.GetMatchConfig();
            GameState = _newMatch.Start();   
        }

        public static void OnRun()
        {
            while (GameState == GameStateEnum.Running)
            {
                GameState = _newMatch.Play();
            }
        }

        private static bool Close()
        {
            System.Console.WriteLine("Do you wanna play again? (y/n)");
            string awnser = System.Console.ReadLine().ToLower();
            while (awnser != "y" && awnser != "n")
            {
                System.Console.WriteLine("Do you wanna play again? (yes = y/no = n)");
                awnser = System.Console.ReadLine().ToLower();
            }
            if (awnser == "y")
                return true;
            return false;
        }
    }
}