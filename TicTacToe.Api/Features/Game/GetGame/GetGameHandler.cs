using MediatR;
using TicTacToe.App;

namespace TicTacToe.Api.Features.Game.GetGame
{
    public class GetGameHandler : IRequestHandler<GetGameQuery, GetGameResponse>
    {
        private readonly IGameService _gameService;
        public GetGameHandler(IGameService gameService)
        {
            _gameService = gameService;
        }
        public async Task<GetGameResponse> Handle(GetGameQuery query, CancellationToken cancellationToken)
        {
            var result = await _gameService.GetGame(query.Id);
            var response = new GetGameResponse
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
