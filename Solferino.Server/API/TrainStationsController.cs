using Microsoft.AspNetCore.Mvc;
using PassengerData.Dto;
using Solferino.BL.Interfaces;



namespace Solferino.Server.Controllers
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

        // GET: api/TrainStations
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<TrainStationDTO>>> GetTrainStations()
        {
            var stations = await _service.GetTrainStations();
            return Ok(stations);

        }

        // GET: api/TrainStations/Filters
        [HttpGet("Filters")]
        public async Task<ActionResult<IEnumerable<TrainStationDTO>>> GetFilteredTrainStations([FromQuery] Filters filters)
        {
            var stations = await _service.GetFilteredTrainStations(filters);
            return Ok(stations);
        }


        // GET: api/TrainStations/Lines
        [HttpGet("Lines")]
        public async Task<ActionResult<IEnumerable<string>>> GetLines()
        {
            var lines = await _service.GetLines();
            return Ok(lines);
        }

    }
}
