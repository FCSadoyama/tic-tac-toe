using System;
using System.Collections.Generic;
using System.Linq;
using tic_tac_toe.enumerators;
using tic_tac_toe.IModels.IProfileLayer;
using tic_tac_toe.Models.BoardLayer;

namespace tic_tac_toe.Models.ProfileLayer
{
    public class Computer : Player
    {
        private DifficultyEnum _difficulty;
        public Computer(string name, MarkEnum mark, DifficultyEnum difficulty)
        {
            this.Name = name;
            this.Mark = mark;
            this._difficulty = difficulty;
        }

        public int EvalBoard(Board board)
        {
            if (this.MarkBoardCenter(board))
            {
                return board.Center;
            }
            return this.GetBestMove(board);
        }

        public int GetBestMove(Board board)
        {
            int position = board.Center;
            if (this.MoveToWin(board, out position))
                return position;
            if (this.MoveToBlock(board, out position))
                return position;
            position = this.FindPossibleFork(board);
            return position;
        }

        public bool MarkBoardCenter(Board board)
        {
            return board.MakeMove(board.Center, this.Mark);
        }

        public bool MoveToWin(Board board, out int position)
        {
            return FindWinOrBlockLine(board, this.Mark, out position);
        }

        public bool MoveToBlock(Board board, out int position)
        {
            return FindWinOrBlockLine(board, this.GetEnemyMark(), out position);
        }

        public bool FindWinOrBlockLine(Board board, MarkEnum mark, out int position)
        {
            position = board.Center;
            Line[] lines = board.GetAllGridLines();

            foreach(Line line in lines)
            {
                if (line.IsPossibleVictoryLine(mark))
                {
                    position = line.GetPossibleWinPosition(mark);
                    return true;
                }
            }

            return false;
        }
        
        public bool MakeRandomMove(Board board, out int position)
        {
            position = board.Center;

            Spot[] spots = board.GetAllGridSpots();
            IList<Spot> nonMarkedSpots = spots.GroupBy(x => x.Type)
                                      .ToDictionary(g => g.Key, g => g.ToList())[MarkEnum.Null];
            position = nonMarkedSpots.ElementAt(new Random().Next(0, nonMarkedSpots.Count)).Position;

            return false;
        }

        public int FindPossibleFork(Board board, int position = 1, int forks = 0)
        {
            
        }

        public int GetForksAmount(Board board)
        {
            int forks = 0;
            Line[] lines = board.GetAllGridLines();

            foreach (Line line in lines)
            {
                if (line.IsPossibleVictoryLine(this.Mark))
                    forks++;
            }

            return forks;
        }
    }
}