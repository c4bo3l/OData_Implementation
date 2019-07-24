using System;
using Microsoft.AspNetCore.Mvc;

namespace OData_Implementation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DateTime.Now.ToLocalTime());
        }
    }
}