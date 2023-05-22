using MediatR;
using TicTacToe.Model;

namespace TicTacToe.Api.Features.Game.MakeMove
{
    public class MakeMoveCommand : IRequest<MakeMoveResponse>
    {
        public Guid GameId { get; set; }
        public Player Player { get; set; }
        public int Position { get; set; }
    }
}
