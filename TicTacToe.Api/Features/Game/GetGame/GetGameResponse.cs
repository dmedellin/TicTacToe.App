using TicTacToe.Model;

namespace TicTacToe.Api.Features.Game.GetGame
{
    public class GetGameResponse
    {
        public Guid Id { get; set; }
        public GameStatus GameStatus { get; set; }
        public Player? NextPlayer { get; set; }
        public List<Marker>? Board { get; set; }

    }
}
