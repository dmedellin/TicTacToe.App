using Dapr.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.App.Persistance;
using TicTacToe.Model;

namespace TicTacToe.Infrastructure.Persistance
{
    public class GameStorage : IGameStorage
    {
        private readonly DaprClient _daprClient;
        private const string storeName = "gamestore";  

        public GameStorage(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        public async Task<Game> GetGame(Guid id)
        {
            return await _daprClient.GetStateAsync<Game>(storeName, id.ToString());
        }

        public async Task SaveGame(Game game)
        {
            await _daprClient.SaveStateAsync(storeName, game.Id.ToString(), game);
        }
    }
}
