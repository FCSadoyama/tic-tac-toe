using System;
using System.Collections.Generic;
using System.Linq;
using tic_tac_toe.Enumerators;
using tic_tac_toe.IModels.IBoardLayer;
using tic_tac_toe.IModels.IProfileLayer;
using tic_tac_toe.Models.BoardLayer;

namespace tic_tac_toe.Models.ProfileLayer
{
    public class AIPlay : AI
    {
        protected override int BestMove { get; set; }

        protected override int GetScore(IBoard board, int depth = 0)
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

        protected override int Minimax(IBoard board, MarkEnum player, DifficultyEnum difficulty, int depth = 0)
        {
            if (board.IsGameOver())
                return this.GetScore(board, depth);
            
            IList<int> scores = new List<int>();
            IList<int> moves = new List<int>();

            var availableSpots = board.GetAvailableGridSpots();
            foreach (ISpot move in availableSpots)
            {
                IBoard newBoard = new Board(board);
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
                return scores.Min();
            }
        }

        protected override void GetMiniMaxPlay(IBoard board, DifficultyEnum difficulty)
        {
            this.Minimax(board, this.Mark, difficulty);
        }

        protected override bool FindWinOrBlockLine(IBoard board, MarkEnum mark)
        {
            ILine[] lines = board.GetAllGridLines();

            foreach(ILine line in lines)
            {
                if (line.IsPossibleVictoryLine(mark))
                {
                    this.BestMove = line.GetPossibleWinPosition(mark);
                    return true;
                }
            }

            return false;
        }
        
        protected override void MakeRandomMove(IBoard board)
        {
            ISpot[] availableSpots = board.GetAvailableGridSpots();
            this.BestMove = availableSpots.ElementAt(new Random().Next(0, availableSpots.Length)).Position;
        }

        protected override int GetGoodMove(IList<int> scores, IList<int> moves)
        {
            int bestOrWorse = new Random().Next(0, 2);
            int selectedMove = 0;
            if (bestOrWorse == 1)
                selectedMove = scores.IndexOf(scores.Max());
            else
                selectedMove = scores.IndexOf(scores.Min());
            return moves[selectedMove];
        }
    }
}