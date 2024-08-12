using Solferino.DAL;
using Microsoft.EntityFrameworkCore;
using Solferino.DAL.Data;
using Solferino.BL.Services;
using Solferino.BL.Interfaces;
using Solferino.DAL.Interfaces;
using Solferino.DAL.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TrainStationContext>(opt =>
    opt.UseInMemoryDatabase("TrainStations"));
builder.Services.AddScoped<ITrainStationService, TrainStationService>();
builder.Services.AddScoped<ITrainStationRepo, TrainStationRepo>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("https://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
var app = builder.Build();

// Seeds
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowReactApp");

app.Run();
