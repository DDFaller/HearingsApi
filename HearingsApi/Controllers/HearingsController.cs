using Microsoft.AspNetCore.Mvc;

namespace HearingsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HearingsController : ControllerBase
    {
        // Load hearings from the JSON file
        List<Hearing> hearings = HearingLoader.LoadHearingsFromJsonFile("data.json");

        private readonly ILogger<HearingsController> _logger;

        public HearingsController(ILogger<HearingsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetHearings")]
        public IEnumerable<Hearing> Get()
        {
            return hearings.ToArray();
        }
    }
}
