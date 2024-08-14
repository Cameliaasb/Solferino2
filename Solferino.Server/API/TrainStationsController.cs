using Microsoft.AspNetCore.Mvc;
using PassengerData.Dto;
using PassengerData.Entities.Entities;
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


        // GET: api/TrainStations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainStationDTO>>> GetTrainStations([FromQuery] Filters filters)
        {
            var stations = await _service.GetTrainStations(filters);
            return Ok(stations);
        }

        // POST: api/TrainStations
        //[HttpPost("{stationId}/PassengerRecord")]
        //public async Task<ActionResult<IEnumerable<TrainStationDTO>>> NewRecord([FromRoute] int stationId, [FromBody] PassengerRecord newRecord )
        //{
        //    // TO DO: Create PassengerRecordDto
        //    // TO DO: Add method in service/repo
            
        //    //return Ok();
        //}

    }
}
