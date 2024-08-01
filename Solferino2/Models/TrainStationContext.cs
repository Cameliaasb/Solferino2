using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Solferino2.Models
{
    public class TrainStationContext : DbContext
    {
        public TrainStationContext(DbContextOptions<TrainStationContext> options) : base(options) {}

        public DbSet<TrainStation> TrainStations { get; set; } = null!;
        public DbSet<PassengerRecord> PassengerRecords { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainStation>().HasKey(station => station.Code);

            modelBuilder.Entity<TrainStation>()
                .HasMany(station => station.PassengerRecords)
                .WithOne()
                .HasForeignKey(record => record.TrainStationCode)
            .IsRequired();



            //// Fake data Seeds

            //modelBuilder.Entity<TrainStation>().HasData(
            //     new TrainStation { Code = 1, Name = "FakeStation1", Latitude = 100, Longitude = 1000 },
            //     new TrainStation { Code = 2, Name = "FakeStation2", Latitude = 10020, Longitude = 33 },
            //     new TrainStation { Code = 3, Name = "FakeStation3", Latitude = 7682, Longitude = 200 },
            //     new TrainStation { Code = 4, Name = "FakeStation4", Latitude = 678, Longitude = 200 },
            //     new TrainStation { Code = 5, Name = "FakeStation5", Latitude = 6789, Longitude = 353 },
            //     new TrainStation { Code = 6, Name = "FakeStation6", Latitude = 987, Longitude = 888 }
            //     );

            //modelBuilder.Entity<PassengerCountRecord>().HasData(
            //    new PassengerCountRecord { Id = 1, Date = new DateTime(2023, 1, 1), PassengerCount = 33, Day = "JOB", TimeRange = "Before6", TrainStationCode = 1 },
            //    new PassengerCountRecord { Id = 2, Date = new DateTime(2023, 1, 1), PassengerCount = 20, Day = "JOB", TimeRange = "From6To10", TrainStationCode = 1 },
            //    new PassengerCountRecord { Id = 3, Date = new DateTime(2023, 1, 1), PassengerCount = 100, Day = "JOB", TimeRange = "After20", TrainStationCode = 1 },
            //    new PassengerCountRecord { Id = 4, Date = new DateTime(2023, 1, 1), PassengerCount = 300, Day = "JOB", TimeRange = "Before6", TrainStationCode = 2 },
            //    new PassengerCountRecord { Id = 5, Date = new DateTime(2023, 1, 1), PassengerCount = 200, Day = "JOB", TimeRange = "After20", TrainStationCode = 2 },
            //    new PassengerCountRecord { Id = 6, Date = new DateTime(2023, 1, 1), PassengerCount = 200, Day = "JOB", TimeRange = "After20", TrainStationCode = 3 },
            //    new PassengerCountRecord { Id = 7, Date = new DateTime(2023, 1, 1), PassengerCount = 3000, Day = "DIM", TimeRange = "From6To10", TrainStationCode = 4 },
            //    new PassengerCountRecord { Id = 8, Date = new DateTime(2023, 1, 1), PassengerCount = 10, Day = "SAM", TimeRange = "After20", TrainStationCode = 5 },
            //    new PassengerCountRecord { Id = 9, Date = new DateTime(2023, 1, 1), PassengerCount = 200, Day = "JOB", TimeRange = "After20", TrainStationCode = 6 }

            //    );


        }
    }
}
