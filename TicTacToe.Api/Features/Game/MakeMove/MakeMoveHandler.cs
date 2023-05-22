using MediatR;
using TicTacToe.App;

namespace TicTacToe.Api.Features.Game.MakeMove
{
    public class MakeMoveHandler : IRequestHandler<MakeMoveCommand, MakeMoveResponse>
    {
        private IGameService _gameService;
        public MakeMoveHandler(IGameService gameService)
        {
            _gameService = gameService;
        }


        public async Task<MakeMoveResponse> Handle(MakeMoveCommand request, CancellationToken cancellationToken)
        {
            await _gameService.MakeMove(new Model.Move
            {
                GameId = request.GameId,
                Player = request.Player,
                Position = request.Position
            });

            return new MakeMoveResponse();
        }
    }
}
