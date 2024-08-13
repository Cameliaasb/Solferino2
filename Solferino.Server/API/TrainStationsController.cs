using Microsoft.AspNetCore.Mvc;
using PassengerData.Dto;
using Solferino.BL.Interfaces;



namespace Solferino.Server.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainStationsController : ControllerBase
    {
        private readonly ITrainStationService _service;


        public TrainStationsController(ITrainStationService service)
        {
            _service = service;
        }


        // GET: api/TrainStations/Filters
        [HttpGet("Filters")]
        public async Task<ActionResult<IEnumerable<TrainStationDTO>>> GetTrainStations([FromQuery] Filters filters)
        {
            var stations = await _service.GetFilteredTrainStations(filters);
            return Ok(stations);
        }

    }
}
