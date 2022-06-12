using DevLabs.Application.Mappers;

namespace DevLabs.APIRest.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(MappingProfileProjeto),
                typeof(MappingProfileAnotacao),
                typeof(MappingProfileMenu)
                );
        }
    }
}