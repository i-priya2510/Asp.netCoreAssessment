using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task4.Modals;

namespace Task4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ModalDbContext _context;

        public SkillsController(ModalDbContext context)
        {
            _context = context;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skills>>> GetSkills()
        {
            var result = await _context.Skills.Include(x => x.SkillMaps).ThenInclude(x => x.Skills).Select(x => new Skills_Employees
            {
                skillid = x.Id,
                name = x.Name,
                Employees = x.SkillMaps.Select(y => y.Employees.Name).ToList()
            }).ToListAsync();
            return result;
        }

    }
}