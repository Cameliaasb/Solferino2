using Microsoft.AspNetCore.Mvc;
using PassengerData.Dto;
using Solferino.BL.Interfaces;



namespace Solferino.Server.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ITrainStationService _service;


        public DataController(ITrainStationService service)
        {
            _service = service;
        }


        // GET: api/data/Lines
        [HttpGet("Lines")]
        public async Task<ActionResult<IEnumerable<string>>> GetLines()
        {
            var lines = await _service.GetLines();
            return Ok(lines);
        }

        // GET: api/data/Years
        [HttpGet("Years")]
        public async Task<ActionResult<IEnumerable<string>>> GetYears()
        {
            var lines = await _service.GetYears();
            return Ok(lines);
        }

    }
}
