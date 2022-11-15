using System;
using Gomoku.Core.Domain;
using Gomoku.Core.Interface;

namespace Gomoku.Infrastructure.Service
{
    public class PlayService : IPlayService
    {
        private int[,] board = new int[15,15];
        public PlayService()
        {
        }

        public async Task<bool> CheckBoardStatus()
        {
            return true;
        }

        public async Task<int> CheckGame(List<Board> board)
        {
            // logic is to get items by batch of 5
            // check if the batch has 5 consecutive id of players
            // if yes, return id of player as winner
            // if no, move to the next batch until winner is found or return no winner

            var winner = 0;
            const int take = 5;
            int skip = 0;
            while (skip < board.Count && winner != 0)
            {
                var batch = board.Skip(skip).Take(take).ToList();
                winner = ProcessBatch(batch);
                skip += take;
            }

            return winner;
        }

        public async Task<List<Board>> HitBoard(int playerId, List<Board> board, string coordinates)
        {
            // check if supplied coordinate is already been hit
            // update board by the coordinate parameter
            // store play by user to a list;

            var winner = 0;
            const int take = 5;
            int skip = 0;
            while (skip < board.Count && winner == 0)
            {
                var batch = board.Skip(skip).Take(take).ToList();
                winner = ProcessBatch(batch);
                skip += take;
            }

            try
            {
                var coordinate = coordinates.Split(',');

                var notHitList = board.Where(x => x.Player == 0).Any(c => c.Column == int.Parse(coordinate[1]) && c.Row == int.Parse(coordinate[0]));

                if (notHitList)
                {
                    var hitBoard = board.FirstOrDefault(c => c.Column == int.Parse(coordinate[1]) && c.Row == int.Parse(coordinate[0]));
                    hitBoard.Player = playerId;
                }
                else
                {
                    Console.WriteLine("box is already hit. Select another.");
                }
                return board;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Board>> NewBoard(int col, int row)
        {
            // create new board dimension can be supplied
            var board = new List<Board>();
            for (int i = 1; i <= 15; i++)
            {
                for (int j = 1; j <= 15; j++)
                {
                    board.Add(new Board { Column = i, Row = j }); ;
                }
            }

            return board;
        }

        private int ProcessBatch(List<Board> board)
        {
            var isPlayer1 = false;
            var isPlayer2 = false;

            int player1Ctr = 0;
            int player2Ctr = 0;

            foreach (var item in board)
            {
                if (item.Player == 1)
                    player1Ctr++;
                else if (item.Player == 2)
                    player2Ctr++;
                

                if (player1Ctr == 5)
                    isPlayer1 = true;
                else if (player2Ctr == 5)
                    isPlayer2 = true;
            }

            if (isPlayer1)
                return 1;
            else if (isPlayer2)
                return 2;
            else
                return 0;
        }
    }
}

