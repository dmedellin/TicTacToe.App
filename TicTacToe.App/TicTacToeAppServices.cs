using Microsoft.Extensions.DependencyInjection;

namespace TicTacToe.App
{
    public static class TicTacToeAppServices
    {
        public static void LoadAppDependencies(this IServiceCollection services)
        {
            services.AddTransient<IGameService, GameService>();
        }
    }
}
