using System;
using System.Collections.Generic;
using System.Linq;
using tic_tac_toe.Models.BoardLayer;

namespace tic_tac_toe.Models.ProfileLayer
{
    public class AIPlay : Player
    {
        private readonly int MaxPlay = 100;
        private readonly int MinPlay = -100;
        private readonly int TiePlay = 0;

        protected int BestMove;

        private int GetScore(Board board, int depth)
        {
            board.IsGameOver();
            MarkEnum mark = board.GetWinner();
            if (mark == this.Mark) //Wins
            {
                return this.MaxPlay - depth;
            }
            else if (mark == this.GetEnemyMark()) //Loses
            {
                return this.MinPlay + depth;
            }
            else //Tie
            {
                return this.TiePlay;
            }
        }

        private int Minimax(Board board, int depth, MarkEnum player)
        {
            if (board.IsGameOver())
                return this.GetScore(board, depth);
            
            depth++;
            IList<int> scores = new List<int>();
            IList<int> moves = new List<int>();

            var availableSpots = board.GetAvailableGridSpots();
            foreach (Spot move in availableSpots)
            {
                Board newBoard = new Board(board);
                newBoard.MakeMove(move.Position, player == this.Mark ? this.Mark:this.GetEnemyMark());
                int result = this.Minimax(newBoard, depth, player == this.Mark ? this.GetEnemyMark():this.Mark);
                scores.Add(result);
                moves.Add(move.Position);
            }

            if(player == this.Mark)
            {
                int maxScoreIndex = scores.IndexOf(scores.Max());
                this.BestMove = moves[maxScoreIndex];
                return scores.Max();
            }
            else
            {
                int minScoreIndex = scores.IndexOf(scores.Min());
                this.BestMove = moves[minScoreIndex];
                return scores.Min();
            }
        }

        protected void GetMiniMaxPlay(Board board)
        {
            this.Minimax(board, 0, this.Mark);
        }

        protected bool FindWinOrBlockLine(Board board, MarkEnum mark)
        {
            Line[] lines = board.GetAllGridLines();

            foreach(Line line in lines)
            {
                if (line.IsPossibleVictoryLine(mark))
                {
                    this.BestMove = line.GetPossibleWinPosition(mark);
                    return true;
                }
            }

            return false;
        }
        
        public void MakeRandomMove(Board board)
        {
            Spot[] availableSpots = board.GetAvailableGridSpots();
            this.BestMove = availableSpots.ElementAt(new Random().Next(0, availableSpots.Length)).Position;
        }
    }
}