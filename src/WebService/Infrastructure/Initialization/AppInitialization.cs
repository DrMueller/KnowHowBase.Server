using Microsoft.AspNetCore.Builder;
using Mmu.Khb.WebService.Infrastructure.Middlewares;

namespace Mmu.Khb.WebService.Infrastructure.Initialization
{
    internal static class AppInitialization
    {
        internal static void InitializeApplication(IApplicationBuilder app)
        {
            InitializeMiddlewares(app);
        }

        private static void InitializeMiddlewares(IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}