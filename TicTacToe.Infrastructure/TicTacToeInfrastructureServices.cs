using Microsoft.Extensions.DependencyInjection;
using TicTacToe.App.Persistance;
using TicTacToe.Infrastructure.Persistance;

namespace TicTacToe.Infrastructure
{
    public static class TicTacToeServices
    {
        public static void LoadInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddDaprClient();
            services.AddTransient<IGameStorage, GameStorage>();
        }
    }
}
