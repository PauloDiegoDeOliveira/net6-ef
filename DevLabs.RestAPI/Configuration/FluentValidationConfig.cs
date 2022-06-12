using DevLabs.Application.Validations.Anotacao;
using DevLabs.Application.Validations.Menu;
using DevLabs.Application.Validations.Projeto;
using FluentValidation.AspNetCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Text.Json.Serialization;

namespace DevLabs.APIRest.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(x =>
                {
                    x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    x.SerializerSettings.Converters.Add(new StringEnumConverter());
                })
                .AddJsonOptions(p =>
                {
                    p.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
                .AddFluentValidation(p =>
                {
                    p.RegisterValidatorsFromAssemblyContaining<PostProjetoValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<PutProjetoValidator>();

                    p.RegisterValidatorsFromAssemblyContaining<PostMenuValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<PutMenuValidator>();

                    p.RegisterValidatorsFromAssemblyContaining<PostAnotacaoValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<PutAnotacaoValidator>();

                    p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
                });
        }
    }
}