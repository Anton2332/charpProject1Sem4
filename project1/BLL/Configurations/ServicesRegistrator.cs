using Microsoft.Extensions.DependencyInjection;
using WEBAPI.BLL.Interfaces;
using WEBAPI.BLL.Services;

namespace WEBAPI.BLL.Configurations
{
    public static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services.AddTransient<IPostService, PostService>()
            .AddTransient<IRepliesService,RepliesService>()
        ;
    }
}
