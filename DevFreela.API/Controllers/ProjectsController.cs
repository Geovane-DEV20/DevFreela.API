using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{

    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {

        private readonly FreelanceTotalCostConfig _config;

        public ProjectsController(IOptions<FreelanceTotalCostConfig> options)
        {
            _config = options.Value;
        }

        // Get api/projects?search=crm

        [HttpGet]
        public IActionResult Get(string search) {
            return Ok();
        }


        // Get api/projects/1234
        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            
            return Ok();    
        }

        // Post api/projects


        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model)
        { 
            if(model.TotalCost < _config.Minimum || model.TotalCost > _config.Maximum)
            {
                return BadRequest("Número fora dos limites");    
            }
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model); //CreatedAction gera o código 201
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProjectInputModel model)
        {

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return NoContent();
        }

        // PUT api/projects/1234/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {

            return NoContent();
        }

        // PUT api/projects/1234/complete
        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id)
        {

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, CreateProjectCommentInputModel model)
        {

            return NoContent();
        }
    }
}
