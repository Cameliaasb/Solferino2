using PassengerData.Dto;

namespace Solferino.BL.Interfaces
{
    public interface ITrainStationService
    {
        Task<IEnumerable<TrainStationDTO>> GetTrainStations();
        Task<IEnumerable<TrainStationDTO>> GetFilteredTrainStations(Filters filters);
        Task<IEnumerable<string>> GetLines();

    }
}
