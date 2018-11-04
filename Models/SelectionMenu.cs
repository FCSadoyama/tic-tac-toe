using System;
using tic_tac_toe.Controllers;
using tic_tac_toe.enumerators;
using tic_tac_toe.IModels;

namespace tic_tac_toe.Models
{
    public static class SelectionMenu
    {
        private static MatchPlayerEnum _matchPlayers;
        private static DifficultyEnum _computerDifficulty;

        public static IMatch GetMatchConfig()
        {
            SelectionMenu.GetMatchPlayers();
            if (!_matchPlayers.Equals(MatchPlayerEnum.HumanVsHuman))
                SelectionMenu.GetDifficulty();
            else
                _computerDifficulty = DifficultyEnum.Disabled;

            return new Match(_matchPlayers, _computerDifficulty);
        }

        private static void GetMatchPlayers()
        {
            _matchPlayers = SelectionMenuController.GetPlayers();
        }

        private static void GetDifficulty()
        {
            _computerDifficulty = SelectionMenuController.GetDifficulty();
        }

        
    }
}