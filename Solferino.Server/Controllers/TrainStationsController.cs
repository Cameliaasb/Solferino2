using Solferino.DAL;
using Microsoft.AspNetCore.Mvc;
using Solferino.BL.Services;
using PassengerData.Dto;



namespace Solferino.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainStationsController : ControllerBase
    {
        private readonly TrainStationContext _context;
        private readonly TrainStationService _service;


        public TrainStationsController(TrainStationContext context, TrainStationService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/TrainStations/PageSize{nb}
        [HttpGet("PageSize{pageSize}")]
        public async Task<ActionResult<IEnumerable<TrainStationDTO>>> GetTrainStations([FromRoute] int pageSize)
        {
            var stations = await _service.GetTrainStations(pageSize);
            return Ok(stations);

        }

        // GET: api/TrainStations/Filters
        [HttpGet("PageSize{pageSize}/Filters")]
        public async Task<ActionResult<IEnumerable<TrainStationDTO>>> GetFilteredTrainStations([FromRoute] int pageSize, [FromQuery] Filters filters)
        {
            var stations = await _service.GetFilteredTrainStations(pageSize, filters);
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
