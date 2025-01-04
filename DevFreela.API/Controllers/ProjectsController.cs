using DevFreela.API.Models;
using DevFreela.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{

    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {

        public ProjectsController()
        {
   
        }

        // Get api/projects?search=crm

        [HttpGet]
        public IActionResult Get(string search = "") {
            return Ok();
        }


        // Get api/projects/1234
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            return Ok();    
        }

        // Post api/projects


        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model)
        { 

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
