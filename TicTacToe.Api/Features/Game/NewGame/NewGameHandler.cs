using MediatR;
using TicTacToe.App;

namespace TicTacToe.Api.Features.Game.NewGame
{
    public class NewGameHandler : IRequestHandler<NewGameRequest, NewGameResponse>
    {
        private readonly IGameService _gameService;
        public NewGameHandler(IGameService gameService)
        {
            _gameService = gameService;
        }
        public async Task<NewGameResponse> Handle(NewGameRequest request, CancellationToken cancellationToken)
        {
            var result = await _gameService.NewGame();
            var response = new NewGameResponse
            {
                Id = result.Id,
                GameStatus = result.GameStatus,
                NextPlayer = result.NextPlayer,
                Board = result.Board
            };

            return response;
        }
    }
}
