

using Microsoft.Extensions.DependencyInjection;

namespace WEBAPI.BLL.Configurations
{
    public static class AutoMapperRegistrator
    {
        public static IServiceCollection AddMapper( this IServiceCollection services) => services
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
