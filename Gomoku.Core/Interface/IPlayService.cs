using System;
using Gomoku.Core.Domain;

namespace Gomoku.Core.Interface
{
    public interface IPlayService
    {
        Task<List<Board>> HitBoard(int playerId, List<Board> board, string coordinate);
        Task<bool> CheckBoardStatus();
        Task<bool> CheckGame();
        Task<List<Board>> NewBoard(int col, int row);

    }
}

