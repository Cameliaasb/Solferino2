using PassengerData.Dto;

namespace Solferino.DAL.Interfaces
{
    public interface ITrainStationRepo
    {
        Task<IEnumerable<TrainStationDTO>> GetTrainStations(Filters filters);
        Task<IEnumerable<string>> GetLines();
        Task<IEnumerable<int>> GetYears();
    }
}