using Microsoft.Extensions.DependencyInjection;
using Solferino.BL.Interfaces;
using Solferino.BL.Services;
using Solferino.DAL;


namespace Solferino.BL
{
    public static class BuilderExtension
    {
        public static void SetupBL(this IServiceCollection services)
        {
            services.SetupDAL();
            services.AddScoped<ITrainStationService, TrainStationService>();
        }

    }
}
