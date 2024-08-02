using Solferino.DAL;
using Solferino.BL.DTOs;
using Solferino.BL.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solferino.BL.Services;



namespace Solferino.Controllers
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


        // GET: api/TrainStations/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TrainStation>> GetTrainStation(int id)
        //{
        //    var trainStation = await _context.TrainStations.FindAsync(id);

        //    if (trainStation == null)
        //    {
        //        return NotFound();
        //    }

        //    return trainStation;
        //}

        // PUT: api/TrainStations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTrainStation(int id, TrainStation trainStation)
        //{
        //    if (id != trainStation.Code)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(trainStation).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TrainStationExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/TrainStations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<TrainStation>> PostTrainStation(TrainStation trainStation)
        //{
        //    _context.TrainStations.Add(trainStation);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTrainStation", new { id = trainStation.Code }, trainStation);
        //}

        // DELETE: api/TrainStations/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTrainStation(int id)
        //{
        //    var trainStation = await _context.TrainStations.FindAsync(id);
        //    if (trainStation == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TrainStations.Remove(trainStation);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool TrainStationExists(int id)
        //{
        //    return _context.TrainStations.Any(e => e.Code == id);
        //}
    }
}
