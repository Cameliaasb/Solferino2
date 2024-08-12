using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Solferino.DAL.Interfaces;
using Solferino.DAL.Repository;

namespace Solferino.DAL
{
    public static class BuilderExtension
    {
        public static void SetupDAL(this IServiceCollection services)
        {
            services.AddScoped<ITrainStationRepo, TrainStationRepo>();
            services.AddDbContext<TrainStationContext>(opt => opt.UseInMemoryDatabase("TrainStations"));
        }
    }
}
