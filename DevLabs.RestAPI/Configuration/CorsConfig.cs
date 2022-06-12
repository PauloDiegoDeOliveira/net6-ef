namespace DevLabs.APIRest.Configuration
{
    public static class CorsConfig
    {
        public static void AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Development", builder =>
                {
                    var development = configuration.GetValue<string>("CorsOrigins").Split(";");
                    builder
                        .WithOrigins(development)
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });

                options.AddPolicy("Production", builder =>
                {
                    var production = configuration.GetValue<string>("CorsOrigins").Split(";");
                    builder
                        .WithOrigins(production)
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });

                options.AddPolicy("Homologation", builder =>
                {
                    var homologation = configuration.GetValue<string>("CorsOrigins").Split(";");
                    builder
                        .WithOrigins(homologation)
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }
    }
}