using Microsoft.EntityFrameworkCore;
using PassengerData.Dto;
using Solferino.DAL.Interfaces;
using Solferino.DAL.Mapper;


namespace Solferino.DAL.Repository
{
    internal class TrainStationRepo : ITrainStationRepo
    {
        private readonly TrainStationContext _context;

        public TrainStationRepo(TrainStationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TrainStationDTO>> GetTrainStations(Filters filters)
        {

            var query = _context.TrainStations
                .Include(t => t.PassengerRecords)
                .Where(s => s.PassengerRecords.Any(r => r.Line == filters.Line))
                .Select(station => station.toDto(filters));

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

    }
}
