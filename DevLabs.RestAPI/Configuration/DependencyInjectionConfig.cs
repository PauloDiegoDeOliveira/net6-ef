using DevLabs.Application.Applications;
using DevLabs.Application.Interfaces;
using DevLabs.Domain.Core.Interfaces.Repositories;
using DevLabs.Domain.Core.Interfaces.Service;
using DevLabs.Domain.Core.Notificacoes;
using DevLabs.Domain.Services;
using DevLabs.Infrastructure.Data.Repositorys;
using DevLabs.RestAPI.Extensions;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DevLabs.APIRest.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryProjeto, RepositoryProjeto>();
            services.AddScoped<IApplicationProjeto, ApplicationProjeto>();
            services.AddScoped<IServiceProjeto, ServiceProjeto>();

            services.AddScoped<IRepositoryAnotacao, RepositoryAnotacao>();
            services.AddScoped<IApplicationAnotacao, ApplicationAnotacao>();
            services.AddScoped<IServiceAnotacao, ServiceAnotacao>();

            services.AddScoped<IRepositoryMenu, RepositoryMenu>();
            services.AddScoped<IApplicationMenu, ApplicationMenu>();
            services.AddScoped<IServiceMenu, ServiceMenu>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddScoped<INotificador, Notificador>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }
    }
}