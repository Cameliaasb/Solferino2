using Microsoft.EntityFrameworkCore;
using PassengerData.Dto;
using PassengerData.Entities.Entities;
using Solferino.DAL.Interfaces;
using Solferino.DAL.Mappers;
using System.Linq.Expressions;


namespace Solferino.DAL.Repository
{
    internal class TrainStationRepo : ITrainStationRepo
    {
        private readonly TrainStationContext _context;


        public TrainStationRepo(TrainStationContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TrainStationDTO>> GetTrainStations()
        {
            var stationDtos = await _context.TrainStations
              .Include(station => station.PassengerRecords)
              .Select(station => station.ToDto())
              .ToListAsync();

            return stationDtos;
        }
        public async Task<IEnumerable<TrainStationDTO>> GetFilteredTrainStations(Filters filters)
        {
            var predicate = CreateFilterPredicate(filters);

            var query = ApplyFilters(_context.TrainStations, filters)
                .Select(station => new TrainStationDTO
                {
                    Name = station.Name,
                    Latitude = station.Latitude,
                    Longitude = station.Longitude,
                    NbOfPassengers = ((int)station.PassengerRecords.AsQueryable()
                        .Where(predicate)
                        .Select(record => record.NbOfPassengers).Average())          // Average per timeRange not per day (*5) !
                });

            var stations = await query.ToListAsync();
            return stations;
        }

        public async Task<IEnumerable<string>> GetLines()
        {
            var lines = await _context.PassengerRecords
                .Select(record => record.Line).Distinct()
                .ToListAsync();

            return lines;
        }

        public async Task<IEnumerable<int>> GetYears()
        {
            var years = await _context.PassengerRecords
                .OrderBy(record => record.Year)
                .Select(record => record.Year).Distinct()
                .ToListAsync();

            return years;
        }


        private static Expression<Func<PassengerRecord, bool>> CreateFilterPredicate(Filters filters)
        {
            return record =>
                (filters.Line == null || record.Line == filters.Line) &&
                (filters.Day == null || (int)record.Day == filters.Day) &&
                (filters.Year == null || record.Year == filters.Year) &&
                (filters.TimeRange == null || (int)record.TimeRange == filters.TimeRange);
        }

        private IQueryable<TrainStation> ApplyFilters(IQueryable<TrainStation> query, Filters filters)
        {
            var predicate = CreateFilterPredicate(filters);
            return query
                .Where(station => station.PassengerRecords.AsQueryable().Any(predicate));
        }
    }
    }
