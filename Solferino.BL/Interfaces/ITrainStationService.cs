using PassengerData.Dto;

namespace Solferino.BL.Interfaces
{
    public interface ITrainStationService
    {
        Task<IEnumerable<TrainStationDTO>> GetFilteredTrainStations(Filters filters);
        Task<IEnumerable<string>> GetLines();
        Task<IEnumerable<int>> GetYears();


    }
}
