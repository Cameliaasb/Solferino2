using PassengerData.Dto;

namespace Solferino.BL.Services
{
    public interface ITrainStationService
    {
        Task<IEnumerable<TrainStationDTO>> GetTrainStations(int pageSize);
        Task<IEnumerable<TrainStationDTO>> GetFilteredTrainStations(int pageSize, Filters filters);
        Task<IEnumerable<string>> GetLines();

    }
}
