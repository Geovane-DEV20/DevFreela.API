using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {

        // Get api/skills
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        //post api/skills
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
