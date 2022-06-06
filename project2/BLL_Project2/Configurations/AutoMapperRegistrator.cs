using Microsoft.Extensions.DependencyInjection;
namespace BLL_Project2.Configurations
{
    public static class AutoMapperRegistrator
    {
        public static IServiceCollection AddMapper(this IServiceCollection services) => services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
