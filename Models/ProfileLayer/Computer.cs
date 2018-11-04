using System;
using System.Collections.Generic;
using System.Linq;
using tic_tac_toe.Enumerators;
using tic_tac_toe.IModels.IBoardLayer;
using tic_tac_toe.IModels.IProfileLayer;
using tic_tac_toe.Models.BoardLayer;

namespace tic_tac_toe.Models.ProfileLayer
{
    public class Computer : AIPlay, IComputer
    {
        public DifficultyEnum Difficulty { get; set; }
        public Computer(string name, MarkEnum mark, DifficultyEnum difficulty)
        {
            this.Name = name;
            this.Mark = mark;
            this.Difficulty = difficulty;
            this.BestMove = 5;
        }

        public int EvalBoard(IBoard board)
        {
            if (this.MarkBoardCenter(board) && this.Difficulty > DifficultyEnum.Easy)
                return board.Center;
            if (this.MoveToWin(board))
                return this.BestMove;
            if (this.MoveToBlock(board))
                return this.BestMove;
            return this.GetBestMove(board);
        }

        public int GetBestMove(IBoard board)
        {
            if (this.Difficulty == DifficultyEnum.Hard)
                this.GetMiniMaxPlay(board, this.Difficulty);
            else if (this.Difficulty == DifficultyEnum.Medium)
                this.MakeRandomMove(board);
            else
                this.MakeRandomMove(board);
            return this.BestMove;
        }

        public bool MarkBoardCenter(IBoard board)
        {
            return board.MakeMove(board.Center, this.Mark);
        }

        public bool MoveToWin(IBoard board)
        {
            return FindWinOrBlockLine(board, this.Mark);
        }

        public bool MoveToBlock(IBoard board)
        {
            return FindWinOrBlockLine(board, this.GetEnemyMark());
        }
    }
}