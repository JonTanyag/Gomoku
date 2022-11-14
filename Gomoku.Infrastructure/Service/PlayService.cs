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

        public async Task<bool> CheckGame()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Board>> HitBoard(int playerId, List<Board> board, string coordinates)
        {
            // check if supplied coordinate is already been hit
            // update board by the coordinate parameter
            // store play by user to a list;

            try
            {
                var coordinate = coordinates.Split(',');

                var notHitList = board.Where(x => !x.isHit).Any(c => c.Column == int.Parse(coordinate[1]) && c.Row == int.Parse(coordinate[0]));

                if (notHitList)
                {
                    var hitBoard = board.FirstOrDefault(c => c.Column == int.Parse(coordinate[1]) && c.Row == int.Parse(coordinate[0]));
                    hitBoard.isHit = true;
                }
                else
                {
                    // show message that coordinate is already hit
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
            var b = new List<Board>();
            var board = new int[col, row];
            for (int i = 1; i <= 15; i++)
            {
                for (int j = 1; j <= 15; j++)
                {
                    b.Add(new Board { Column = i, Row = j }); ;
                }
            }

            return b;
        }
    }
}

