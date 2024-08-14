using PassengerData.Dto;
using PassengerData.Entities.Entities;
using System.Linq.Expressions;

namespace Solferino.DAL.Mapper
{
    internal static class TrainStationMapper
    {
        public static TrainStationDTO toDto(this TrainStation station, Filters filters)
        {
            var predicate = CreateFilterPredicate(filters);

            var passengers = station.PassengerRecords.AsQueryable().Where(predicate).ToList();
            var passengersAverage = 0;
            if (passengers.Count() != 0) passengersAverage = (int)passengers.Select(record => record.NbOfPassengers).Average();


            var trainStationDTO = new TrainStationDTO
            {
                Name = station.Name,
                Latitude = station.Latitude,
                Longitude = station.Longitude,
                NbOfPassengers = passengersAverage,
                Lines = getStationLines(station.PassengerRecords.ToList())
            };

            return trainStationDTO;
        }

        private static Expression<Func<PassengerRecord, bool>> CreateFilterPredicate(Filters filters)
        {
            return record =>
                (record.Line == filters.Line) &&
                (filters.Year == null || record.Year == filters.Year) &&
                (filters.Day == null || (int)record.Day == filters.Day) &&
                (filters.TimeRange == null || (int)record.TimeRange == filters.TimeRange);
        }

        private static List<string> getStationLines(List<PassengerRecord> records)
        {
            return records.Select(record => record.Line).Distinct().ToList();
        }

    }
}
