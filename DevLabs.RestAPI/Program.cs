using DevLabs.APIRest.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configurationManager = builder.Configuration;

IWebHostEnvironment environment = builder.Environment;

builder.Services.AddControllers();

builder.Services.AddJwtTConfiguration(configurationManager);

builder.Services.AddFluentValidationConfiguration();

builder.Services.AddAutoMapperConfiguration();

builder.Services.AddDatabaseConfiguration(configurationManager);

builder.Services.AddDependencyInjectionConfiguration();

builder.Services.AddSwaggerConfig();

builder.Services.AddCorsConfiguration(configurationManager);

builder.Services.AddVersionConfiguration();

builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

if (app.Environment.IsDevelopment())
{
    app.UseCors("Development");
    app.UseDeveloperExceptionPage();
}
else if (app.Environment.IsProduction())
{
    app.UseCors("Production");
    app.UseHsts();
}
else
{
    app.UseCors("Homologation");
}

app.UseDatabaseConfiguration();

app.UseSwaggerConfig(environment, provider);

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();