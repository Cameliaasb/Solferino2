using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.DependencyInjection;
using PassengerData.Entities.Entities;
using PassengerData.Entities.Enums;

namespace Solferino.DAL.Seeds
{
    public static class SeedData
    {
        public async static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new TrainStationContext(
                serviceProvider.GetRequiredService<DbContextOptions<TrainStationContext>>());

            if (context.TrainStations.Any()) return;

            var trainStationsJson = File.ReadAllText("Data\\TrainStations.json");
            var passengerRecordsJson = File.ReadAllText("Data\\PassengerRecords.json");

            var trainStations = JsonConvert.DeserializeObject<List<JObject>>(trainStationsJson);
            var passengerRecords = JsonConvert.DeserializeObject<List<JObject>>(passengerRecordsJson);


            if (trainStations is not null)
            {
                var stationsToAdd = LoadTrainStations(trainStations);
                await context.TrainStations.AddRangeAsync(stationsToAdd);
            }

            if (passengerRecords is not null)
            {
                var passengerRecordsToAdd = LoadPassengerRecords(passengerRecords);
                await context.PassengerRecords.AddRangeAsync(passengerRecordsToAdd);
            }

            context.SaveChanges();

            // Delete train stations without passenger data
            var trainStationsToDelete = await context.TrainStations.Where(s => s.PassengerRecords.Count == 0).ToListAsync();
            context.TrainStations.RemoveRange(trainStationsToDelete);
            context.SaveChanges();
        }

        private static List<TrainStation> LoadTrainStations(List<JObject> trainStations)
        {

            return trainStations
                .Select(t => new TrainStation
                {
                    Code = t["code_uic"]!.ToString(),
                    Name = t["libelle"]!.ToString(),
                    Latitude = t["c_geo"]!["lat"]!.Value<float>(),
                    Longitude = t["c_geo"]!["lon"]!.Value<float>(),
                })
                .GroupBy(station => station.Code)
                .Select(station => station.First())
                .ToList();
        }

        private static List<PassengerRecord> LoadPassengerRecords(List<JObject> passengerRecords)
        {

            return passengerRecords
                .Select(t => new PassengerRecord
                {
                    Date = t["date"]!.Value<DateTime>(),
                    Day = t["jour"]!.ToDayType(),
                    TimeRange = t["par_periode_horaire"]!.ToTimeRange(),
                    NbOfPassengers = t["montees"]!.Value<int>(),
                    TrainStationCode = t["codegare"]!.ToString(),
                    Line = t["ligne"]!.ToString(),
                })
                .ToList();
        }

        private static DayType ToDayType(this JToken day)
        {
            return (DayType)Enum.Parse(typeof(DayType), day.ToString());
        }
        private static TimeRange ToTimeRange(this JToken range)
        {
            switch (range.ToString())
            {
                case "Avant 6h":
                    return TimeRange.Before6;
                case "De 6h à 10h":
                    return TimeRange.From6To10;
                case "De 10h à 16h":
                    return TimeRange.From10To16;
                case "De 16h à 20h":
                    return TimeRange.From16To20;
                default:
                    return TimeRange.After20;
            }
        }
    }
}
;