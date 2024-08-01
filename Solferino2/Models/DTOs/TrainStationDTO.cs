﻿namespace Solferino2.Models.DTOs
{
    public class TrainStationDTO
    {
        public required string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int NbOfPassengers { get; set; }
    }
}
