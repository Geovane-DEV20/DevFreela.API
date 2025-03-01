﻿
using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;
        public SkillsController(DevFreelaDbContext context)
        {
            _context = context; 
        }
        // Get api/skills
        [HttpGet]
        public IActionResult GetAll()
        {
            var skills = _context.Skills.ToList();

            return Ok(skills);
        }

        //post api/skills
        [HttpPost]
        public IActionResult Post(CreateSkilInputModel model)
        {
            var skill = new Skill(model.Description);
            _context.Skills.Add(skill);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
