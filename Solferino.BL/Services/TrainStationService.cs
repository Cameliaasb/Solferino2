using Microsoft.EntityFrameworkCore;
using PassengerData.Entities.Entities;
using Solferino.BL.DTOs;
using Solferino.BL.Mappers;
using Solferino.DAL;


namespace Solferino.BL.Services
{
    public class TrainStationService : ITrainStationService
    {
        private readonly TrainStationContext _context;
        private readonly IQueryable<TrainStation> _baseQuery;


        public TrainStationService(TrainStationContext context)
        {
            _context = context;
            _baseQuery = _context.TrainStations
                .Include(station => station.PassengerRecords);
        }


        public async Task<IEnumerable<TrainStationDTO>> GetTrainStations(int pageSize)
        {
            var stationDtos = await _baseQuery
              .Take(pageSize)
              .Select(station => station.ToDto())
              .ToListAsync();

            return stationDtos;
        }

        public async Task<IEnumerable<TrainStationDTO>> GetFilteredTrainStations(int pageSize, Filters filters)
        {
            var stations = await ApplyFilters(_baseQuery, filters).ToListAsync();

            var stationDtos = stations
                .Select(s => s.ToDto())
                .OrderBy(s => s.NbOfPassengers)
                .Take(pageSize)
                .ToList();

            return stationDtos;
        }

        public async Task<IEnumerable<string>> GetLines()
        {
            var lines = await _context.PassengerRecords
                .Select(record => record.Line).Distinct()
                .ToListAsync();

            return lines;
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
