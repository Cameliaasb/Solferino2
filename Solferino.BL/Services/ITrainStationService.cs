using Solferino.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solferino.BL.Services
{
    public interface ITrainStationService
    {
        Task<IEnumerable<TrainStationDTO>> GetTrainStations(int pageSize);
        Task<IEnumerable<TrainStationDTO>> GetFilteredTrainStations(int pageSize, Filters filters);
    }
}
