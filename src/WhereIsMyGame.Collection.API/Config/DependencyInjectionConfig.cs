using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WhereIsMyGame.Collection.API.Data;
using WhereIsMyGame.Collection.API.Data.Repositories;
using WhereIsMyGame.WebApi.Core.Users;

namespace WhereIsMyGame.Collection.API.Config
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUser, AspNetUser>();

            services.AddScoped<IGameRepository, GameRepository>();
            
            services.AddScoped<CollectionContext>();
        }
    }
}