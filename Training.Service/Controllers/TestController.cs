using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.RA.Interfaces;

namespace Training.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IAutopartRepository _autopartRepository;

        public TestController(IAutopartRepository autopartRepository)
        {
            _autopartRepository = autopartRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAutopart()
        {
            return Ok(await _autopartRepository.GetAllAsync());
        }
    }
}
