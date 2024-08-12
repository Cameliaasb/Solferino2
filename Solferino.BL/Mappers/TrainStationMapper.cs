using PassengerData.Entities.Entities;
using Solferino.BL.DTOs;

namespace Solferino.BL.Mappers
{
    public static class TrainStationMapper
    {
        public static TrainStationDTO ToDto(this TrainStation trainStation)
        {
            var trainDto = new TrainStationDTO
            {
                Name = trainStation.Name,
                Latitude = trainStation.Latitude,
                Longitude = trainStation.Longitude,
                NbOfPassengers = trainStation.PassengerRecords.Sum(record => record.NbOfPassengers)
            };
            return trainDto;
        }
    }
}
