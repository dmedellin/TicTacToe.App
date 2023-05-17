using TicTacToe.Model;

namespace TicTacToe.App.Persistance
{
    public interface IGameStorage
    {
        public Task<Game> GetGame(Guid id);
        public Task SaveGame(Game game);
    }
}
