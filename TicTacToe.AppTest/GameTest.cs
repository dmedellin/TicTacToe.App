using FluentAssertions;
using TicTacToe.App;
using TicTacToe.Model;

namespace TicTacToe.AppTest
{
    public class GameTest
    {
        private MockGameStorage _mockGameStorage;
        public GameTest()
        {
            _mockGameStorage = new MockGameStorage();
        }
        [Fact]
        public async Task NewGameShould_HaveCorrectInitialState_WithFluentAssertions()
        {
            // Arrange: Create a new game
            var mockGameStorage = _mockGameStorage;

            var gameService = new GameService(mockGameStorage);

            // Act: Create a new game
            var game = await gameService.NewGame();

            // Assert: Check that the game has the correct initial state
            game.GameStatus.Should().Be(GameStatus.InProgress);
            game.NextPlayer.Should().Be(Player.X);
            game.Board.Should().NotBeNullOrEmpty();
            game.Board.Should().OnlyContain(square => square == Marker.Empty);
        }

        [Fact]
        public async Task MakeMoveShould_UpdateGame_WithFluentAssertions()
        {
            // Arrange: Create a new game
            var mockGameStorage = _mockGameStorage;
            var gameService = new GameService(mockGameStorage);
            var game = await gameService.NewGame();

            var move = new Move { Player = Player.X, Position = 0, GameId = game.Id };

            // Act: Make a move
            await gameService.MakeMove(move);

            // Assert: Check that the game has the correct state
            var updatedGame = await gameService.GetGame(game.Id);
            updatedGame.GameStatus.Should().Be(GameStatus.InProgress);
            updatedGame.NextPlayer.Should().Be(Player.O);
            updatedGame.Board.Should().NotBeNullOrEmpty();
            updatedGame.Board.Should().HaveCount(9);
            updatedGame.Board[0].Should().Be(Marker.X);
            updatedGame.Board.Should().OnlyContain(square => square == Marker.Empty || square == Marker.X);
        }

        [Fact]
        public async Task MakeMove_ShouldRejectOutOfTurn()
        {
            // Arrange: Create a new game
            var mockGameStorage = _mockGameStorage;
            var gameService = new GameService(mockGameStorage);
            var game = await gameService.NewGame();

            // Define two moves by the same player  
            var move1 = new Move { Player = Player.X, Position = 0, GameId = game.Id };
            var move2 = new Move { Player = Player.X, Position = 1, GameId = game.Id };

            // Act: Make the first move
            await gameService.MakeMove(move1);

            //assert that the second move is rejected
            Func<Task> act = async () => await gameService.MakeMove(move2);
            await act.Should().ThrowAsync<Exception>().WithMessage("wrong player");

        }

        [Fact]
        public async Task MakeMove_ShouldRejectOccupiedPosition()
        {
            // Arrange: Create a new game and make a move
            var mockGameStorage = _mockGameStorage;
            var gameService = new GameService(mockGameStorage);
            var game = await gameService.NewGame();
            var firstMove = new Move { GameId = game.Id, Player = Player.X, Position = 0 };
            await gameService.MakeMove(firstMove);

            // Define a second move to the same position
            var secondMove = new Move { GameId = game.Id, Player = Player.O, Position = 0 };

            // Act and Assert: Making the second move should throw an exception
            Func<Task> act = () => gameService.MakeMove(secondMove);
            await act.Should().ThrowAsync<InvalidOperationException>().WithMessage("square is not empty");
        }
    }
}