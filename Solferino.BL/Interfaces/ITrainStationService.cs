using PassengerData.Dto;

namespace Solferino.BL.Interfaces
{
    public interface ITrainStationService
    {
        Task<IEnumerable<TrainStationDTO>> GetTrainStations(Filters filters);
        Task<IEnumerable<string>> GetLines();
        Task<IEnumerable<int>> GetYears();


    }
}
