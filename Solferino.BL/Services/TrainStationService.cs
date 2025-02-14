﻿
using PassengerData.Dto;
using Solferino.BL.Interfaces;
using Solferino.DAL.Interfaces;

namespace Solferino.BL.Services
{
    public class TrainStationService : ITrainStationService
    {
        private readonly ITrainStationRepo _trainStationRepo;

        public TrainStationService(ITrainStationRepo trainStationRepo)
        {
            _trainStationRepo = trainStationRepo;
        }

        public Task<IEnumerable<TrainStationDTO>> GetTrainStations(Filters filters)
        {
            return _trainStationRepo.GetTrainStations(filters);
        }

        public Task<IEnumerable<string>> GetLines()
        {
            return _trainStationRepo.GetLines();
        }


        public Task<IEnumerable<int>> GetYears()
        {
            return _trainStationRepo.GetYears();
        }
    }
}
