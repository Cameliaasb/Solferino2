using Microsoft.Extensions.DependencyInjection;
using Solferino.DAL.Seeds;

namespace Solferino.BL
{
    public static class AppExtension
    {
        public static void SeedDatabase(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                SeedData.Initialize(services);
            }
        }
    }
}
