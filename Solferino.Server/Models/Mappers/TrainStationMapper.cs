﻿//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using Solferino.Models.DTOs;

//namespace Solferino.Models.Mappers
//{
//    public static class TrainStationMapper
//    {
//        public static TrainStationDTO ToDto(this TrainStation trainStation)
//        {
//            var trainDto = new TrainStationDTO
//            {
//                Name = trainStation.Name,
//                Latitude = trainStation.Latitude,
//                Longitude = trainStation.Longitude,
//                NbOfPassengers = trainStation.PassengerRecords.Sum(record => record.NbOfPassengers)
//            };
//            return trainDto;
//        }
//    }
//}
