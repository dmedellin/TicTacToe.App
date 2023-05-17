namespace TicTacToe.Model
{
    public class Game
    {
        public Guid Id { get; set; }
        public GameStatus GameStatus { get; set; }
        public Player? NextPlayer { get; set; }
        public List<Marker>? Board { get; set; }
    }
    public enum GameStatus
    {
        InProgress,
        Draw,
        XWins,
        OWins
    }

    public enum Marker
    {
        Empty,
        X,
        O
    }
    public enum Player
    {
        X,
        O
    }
}