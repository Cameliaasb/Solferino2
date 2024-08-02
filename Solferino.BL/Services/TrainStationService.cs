using Microsoft.EntityFrameworkCore;
using Solferino.BL.DTOs;
using Solferino.BL.Mappers;
using Solferino.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
