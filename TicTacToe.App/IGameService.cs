using TicTacToe.Model;

namespace TicTacToe.App
{
    public interface IGameService
    {
        Task<Game> GetGame(Guid id);
        Task MakeMove(Move move);
        Task<Game> NewGame();
    }
}