using Microsoft.Extensions.DependencyInjection;
using Startimes.Service.Modules.StartTimes.Handler;
using Startimes.Service.Modules.StartTimes.Interface;

namespace Startimes.Service.Modules
{
    public static class AppBootsrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // ASP.NET HttpContext dependency


            services.AddScoped<IStartimesPaymentApiService, StartimesPaymentApiService>();
        }
    }
}
