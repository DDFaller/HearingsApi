using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace HearingsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HearingsController : ControllerBase
    {
        // Load hearings from the JSON file
        List<Hearings> hearings = HearingLoader.LoadHearingsFromJsonFile("Data/data.json");

        private readonly ILogger<HearingsController> _logger;
        private AppDbContext _dbContext;

        public HearingsController(ILogger<HearingsController> logger)
        {
            string connectionString = "Server=tcp:hearings.database.windows.net,1433;Initial Catalog=hearings;Persist Security Info=False;User ID=hearings-admin;Password=lumacaD@0812;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            _logger = logger;

            // The variable dbContextOptions, should be passed via the HearingsController constructor, also connectionString should be in a options file.
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlServer(connectionString)
                    .Options;
            _dbContext = new AppDbContext(dbContextOptions);
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<Hearings> Get()
        {
            return hearings.ToArray();
        }

        [HttpGet]
        [Route("GetFromDB")]
        public IEnumerable<Hearings> GetFromDB()
        {
            return _dbContext.Hearings.ToList();
        }

        [HttpGet("{processNumber}")]
        public IActionResult GetFromDB(string processNumber)
        {
            var hearing = _dbContext.Hearings.FirstOrDefault(h => h.processNumber == processNumber);

            if (hearing == null)
                return NotFound();

            return Ok(hearing);
        }

        [HttpPost]
        [Route("AddToDB")]
        public IActionResult AddToDB([FromBody] Hearings hearing)
        {
            _dbContext.Hearings.Add(hearing);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetFromDB), new { processNumber = hearing.processNumber }, hearing);
        }

        [HttpPut("{processNumber}")]
        public IActionResult UpdateInDB(string processNumber, [FromBody] Hearings hearing)
        {
            var existingHearing = _dbContext.Hearings.FirstOrDefault(h => h.processNumber == processNumber);

            if (existingHearing == null)
                return NotFound();

            existingHearing.date = hearing.date;
            existingHearing.court = hearing.court;
            existingHearing.correspondent = hearing.correspondent;

            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{processNumber}")]
        public IActionResult DeleteFromDB(string processNumber)
        {
            var existingHearing = _dbContext.Hearings.FirstOrDefault(h => h.processNumber == processNumber);

            if (existingHearing == null)
                return NotFound();

            _dbContext.Hearings.Remove(existingHearing);
            _dbContext.SaveChanges();

            return NoContent();
        }

    }
}
