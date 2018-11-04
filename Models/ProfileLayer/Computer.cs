using System;
using System.Collections.Generic;
using System.Linq;
using tic_tac_toe.enumerators;
using tic_tac_toe.IModels.IProfileLayer;
using tic_tac_toe.Models.BoardLayer;

namespace tic_tac_toe.Models.ProfileLayer
{
    public class Computer : AIPlay
    {
        public DifficultyEnum _difficulty;
        public Computer(string name, MarkEnum mark, DifficultyEnum difficulty)
        {
            this.Name = name;
            this.Mark = mark;
            this._difficulty = difficulty;
            this.BestMove = 5;
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
            if (this.MoveToWin(board))
                return this.BestMove;
            if (this.MoveToBlock(board))
                return this.BestMove;
            
            if (this._difficulty == DifficultyEnum.Hard)
            {
                this.GetMiniMaxPlay(board);
                return this.BestMove;
            }
            else if (this._difficulty == DifficultyEnum.Medium)
            {
                this.MakeRandomMove(board);
                return this.BestMove;
            }
            this.MakeRandomMove(board);
            return this.BestMove;
        }

        public bool MarkBoardCenter(Board board)
        {
            return board.MakeMove(board.Center, this.Mark);
        }

        public bool MoveToWin(Board board)
        {
            return FindWinOrBlockLine(board, this.Mark);
        }

        public bool MoveToBlock(Board board)
        {
            return FindWinOrBlockLine(board, this.GetEnemyMark());
        }
    }
}