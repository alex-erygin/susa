using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Susanin.Api.Contracts;
using Susanin.Api.Data;

namespace Susanin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoadmapController : ControllerBase
    {
        private readonly ILogger<RoadmapController> _logger;

        public RoadmapController(ILogger<RoadmapController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<RoadmapItem> Get()
        {
            var context = new RoadmapDbContext();
            var items = context.Roadmap.Select(x => x).ToArray();
            return items;
        }
    }
}