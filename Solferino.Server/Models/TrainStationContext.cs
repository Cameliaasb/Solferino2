using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Solferino.Models
{
    //public class TrainStationContext : DbContext
    //{
    //    public TrainStationContext(DbContextOptions<TrainStationContext> options) : base(options) {}

    //    public DbSet<TrainStation> TrainStations { get; set; } = null!;
    //    public DbSet<PassengerRecord> PassengerRecords { get; set; } = null!;

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<TrainStation>().HasKey(station => station.Code);

    //        modelBuilder.Entity<TrainStation>()
    //            .HasMany(station => station.PassengerRecords)
    //            .WithOne()
    //            .HasForeignKey(record => record.TrainStationCode)
    //        .IsRequired();
        //}
    //}
}
