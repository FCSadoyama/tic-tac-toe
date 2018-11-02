using System;
using System.Collections.Generic;
using tic_tac_toe.enumerators;
using tic_tac_toe.Models.BoardLayer;
using tic_tac_toe.Models.ProfileLayer;

namespace tic_tac_toe.Models
{
    public class Match
    {
        private Board _board;
        private MatchPlayerEnum _matchPlayers;
        private DifficultyEnum _computerDifficulty;

        private Player[] _players;
        private int _playerPlaying;

        public Match(MatchPlayerEnum matchPlayers, DifficultyEnum computerDifficulty)
        {
            this._board = new Board();
            this._matchPlayers = matchPlayers;
            this._computerDifficulty = computerDifficulty;
            this.ConfigMatch();
        }

        private void ConfigMatch()
        {
            if (_matchPlayers == MatchPlayerEnum.ComputerVsComputer)
            {
                this._players = new Player[2]
                {
                    new Computer("Computer X", MarkEnum.X, this._computerDifficulty), new Computer("Computer O", MarkEnum.O, this._computerDifficulty)
                };
            }
            else if (_matchPlayers == MatchPlayerEnum.HumanVsComputer)
            {
                this._players = new Player[2]
                {
                    new Human("Human X", MarkEnum.X), new Computer("Computer O", MarkEnum.O, this._computerDifficulty)
                };
            }
            else 
            {
                this._players = new Player[2]
                {
                    new Human("Human X", MarkEnum.X), new Human("Human O", MarkEnum.O)
                };
            }

            this._playerPlaying = new Random().Next(0, 2);
        }

        public GameStateEnum Start()
        {
            return GameStateEnum.Running;
        }

        public GameStateEnum Play()
        {
            System.Console.Clear();
            System.Console.WriteLine("And the starting player is... {0}!", this._players[this._playerPlaying].Name);
            this._board.Draw();
            Computer comp = this._players[this._playerPlaying] as Computer;
            if (comp != null)
            {
                int bestMove = comp.EvalBoard(this._board);
                this._board.MakeMove(bestMove, comp.Mark);
            }
            else
            {
                Human human = this._players[this._playerPlaying] as Human;
                bool IsSpotAvailable = this._board.MakeMove(human.GetSpot(), human.Mark);
                while (!IsSpotAvailable)
                    IsSpotAvailable = this._board.MakeMove(human.GetSpot(false), human.Mark);
            }

            if (this._playerPlaying == 1)
                this._playerPlaying--;
            else
                this._playerPlaying++;

            return this.CheckMatchOver();
        }

        public GameStateEnum CheckMatchOver()
        {
            if (_board.IsGameOver(out MarkEnum mark))
            {
                System.Console.Clear();
                _board.Draw();
                string winner = _players[0].Mark == mark ? _players[0].Name:_players[1].Name;
                string message = mark == MarkEnum.Null ? 
                                            "And the game ends in a tie!" :
                                            $"And the winner is... {winner}!";
                System.Console.WriteLine(message);
                
                return GameStateEnum.Over;
            }
            return GameStateEnum.Running;
        }
    }
}