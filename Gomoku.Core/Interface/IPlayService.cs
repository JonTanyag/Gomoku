using System;
using Gomoku.Core.Domain;

namespace Gomoku.Core.Interface
{
    public interface IPlayService
    {
        Task<List<Board>> HitBoard(int playerId, List<Board> board, string coordinate);
        Task<int> CheckGame(List<Board> board);
        Task<List<Board>> NewBoard(int col, int row);

    }
}

