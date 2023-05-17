using TicTacToe.App.Persistance;
using TicTacToe.Model;

namespace TicTacToe.App
{
    public class GameService : IGameService
    {
        private readonly IGameStorage _storageClient;

        public GameService(IGameStorage storageClient)
        {
            _storageClient = storageClient;
        }
        public async Task<Game> GetGame(Guid id)
        {
            var game = await _storageClient.GetGame(id);

            if (game == null)
            {
                throw new ArgumentException("Invalid game ID");
            }

            return game;
        }

        public async Task MakeMove(Move move)
        {
            var game = await GetGame(move.GameId);

            if (move.Player != game.NextPlayer)
                throw new Exception("wrong player");

            if (game.Board[move.Position] != Marker.Empty)
                throw new InvalidOperationException("square is not empty");

            game.Board[move.Position] = move.Player == Player.X ? Marker.X : Marker.O;
            game.NextPlayer = move.Player == Player.X ? Player.O : Player.X;

            await _storageClient.SaveGame(game);

        }

        public async Task<Game> NewGame()
        {
            var game = new Game
            {
                Id = Guid.NewGuid(),
                GameStatus = GameStatus.InProgress,
                NextPlayer = Player.X,
                Board = new List<Marker>
                {
                    Marker.Empty, Marker.Empty, Marker.Empty,
                    Marker.Empty, Marker.Empty, Marker.Empty,
                    Marker.Empty, Marker.Empty, Marker.Empty
                }
            };

            await _storageClient.SaveGame(game);

            return game;
        }

    }
}