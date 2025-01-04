using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{

    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {

        //POST api/users
        [HttpPost]
        public IActionResult Post(CreateUserInputModel model)
        {
            return NoContent();        
        }

        [HttpPost("{id}/skills")]
        public IActionResult PostSkills(UserSkillsInputModel model) { 
        

                
            return NoContent(); 
        }


        //POST api/users
        [HttpPut("{id}/profile-picture")]
        public IActionResult PostProfilePicture(IFormFile file)
        {
            var description = $"File: {file.FileName}, Size: {file.Length} ";
            // Processar a imagem
            
            return Ok(description);
        }
    }
}
