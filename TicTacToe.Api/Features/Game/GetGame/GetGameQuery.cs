using MediatR;

namespace TicTacToe.Api.Features.Game.GetGame
{
    public class GetGameQuery : IRequest<GetGameResponse>
    {
        public Guid Id { get; set; }

        public GetGameQuery(Guid id)
        {
            Id = id;
        }
    }
}
