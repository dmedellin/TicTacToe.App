using TicTacToe.App.Persistance;
using TicTacToe.Model;

namespace TicTacToe.AppTest
{
    public class MockGameStorage : IGameStorage
    {
        public static Dictionary<Guid, Game> Games = new Dictionary<Guid, Game>();
        public Task<Game> GetGame(Guid id)
        {
            var game = Games[id];
            return Task.FromResult(game);
        }

        public Task SaveGame(Game game)
        {
            Games[game.Id] = game;
            return Task.CompletedTask;
        }
    }
}
