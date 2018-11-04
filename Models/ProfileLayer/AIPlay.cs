using System;
using System.Collections.Generic;
using System.Linq;
using tic_tac_toe.enumerators;
using tic_tac_toe.Models.BoardLayer;

namespace tic_tac_toe.Models.ProfileLayer
{
    public class AIPlay : Player
    {
        private readonly int MaxPlay = 100;
        private readonly int MinPlay = -100;
        private readonly int TiePlay = 0;

        protected int BestMove;

        private int GetScore(Board board, int depth = 0)
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

        private int Minimax(Board board, MarkEnum player, DifficultyEnum difficulty, int depth = 0)
        {
            if (board.IsGameOver())
                return this.GetScore(board, depth);
            
            IList<int> scores = new List<int>();
            IList<int> moves = new List<int>();

            var availableSpots = board.GetAvailableGridSpots();
            foreach (Spot move in availableSpots)
            {
                Board newBoard = new Board(board);
                newBoard.MakeMove(move.Position, player == this.Mark ? this.Mark:this.GetEnemyMark());
                int result = this.Minimax(newBoard, this.SwitchMark(player), difficulty, depth++);
                scores.Add(result);
                moves.Add(move.Position);
            }

            if(player == this.Mark)
            {
                int maxScoreIndex = 0;
                if (difficulty == DifficultyEnum.Hard)
                {
                    maxScoreIndex = scores.IndexOf(scores.Max());
                    this.BestMove = moves[maxScoreIndex];
                }
                else
                {
                    maxScoreIndex = scores.IndexOf(scores.Max());
                    this.BestMove = this.GetGoodMove(scores, moves);
                }
                return scores.Max();
            }
            else
            {
                int minScoreIndex = 0;
                if (difficulty == DifficultyEnum.Hard)
                {
                    minScoreIndex = scores.IndexOf(scores.Min());
                    this.BestMove = moves[minScoreIndex];
                }
                else
                {
                    minScoreIndex = scores.IndexOf(scores.Min());
                    this.BestMove = this.GetGoodMove(scores, moves);
                }
                
                return scores.Min();
            }
        }

        protected void GetMiniMaxPlay(Board board, DifficultyEnum difficulty)
        {
            this.Minimax(board, this.Mark, difficulty);
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
        
        protected void MakeRandomMove(Board board)
        {
            Spot[] availableSpots = board.GetAvailableGridSpots();
            this.BestMove = availableSpots.ElementAt(new Random().Next(0, availableSpots.Length)).Position;
        }

        private int GetGoodMove(IList<int> scores, IList<int> moves)
        {
            int MaxOrMin = 3;
            while (scores.Count > 1)
            {
                int x;
                if (MaxOrMin > 0)
                    x = scores.IndexOf(scores.Max());
                else
                    x = scores.IndexOf(scores.Min());
                
                scores.Remove(x);
                moves.Remove(x);
                MaxOrMin = MaxOrMin == 3 ? 0:MaxOrMin++;
            }
            return moves[0];
        }
    }
}