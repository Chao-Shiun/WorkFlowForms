using Microsoft.AspNetCore.Mvc;

namespace WorkFlowForms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocController : ControllerBase
    {
        // GET: api/doc
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is the DocController responding!");
        }

        // POST: api/doc
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            // 處理接收到的資料
            return Ok($"Received: {value}");
        }
    }
} 