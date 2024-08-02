using Microsoft.EntityFrameworkCore;
using Solferino.BL.DTOs;
using Solferino.BL.Mappers;
using Solferino.DAL;
using Solferino.DAL.Entities;
using System.Reflection;

namespace Solferino.BL.Services
{
    public class TrainStationService : ITrainStationService
    {
        private readonly TrainStationContext _context;

        public TrainStationService(TrainStationContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TrainStationDTO>> GetTrainStations(int pageSize)
        {
            var stations = await _context.TrainStations
              .Include(station => station.PassengerRecords)
              .Take(pageSize)
              .Select(station => station.ToDto())
              .ToListAsync();

            return stations;
        }

        public async Task<IEnumerable<TrainStationDTO>> GetFilteredTrainStations(Filters filters)
        {

            IQueryable<TrainStation> baseQuery = _context.TrainStations
              .Include(station => station.PassengerRecords);

            var query = ApplyFilters(baseQuery, filters);

            var stations = await query.ToListAsync();

            var dtos = stations
                .Select(s => s.ToDto())
                .OrderBy(s => s.NbOfPassengers)
                .Take(10)
                .ToList();
            return dtos;
        }


        private IQueryable<TrainStation> ApplyFilters (IQueryable<TrainStation> query, Filters filters)
        {

            if (filters.Line is not null)
            {
                query = query
                  .Where(station => station.PassengerRecords.Any(record => record.Line == filters.Line));
            }

            return query;
        }

    }
}
