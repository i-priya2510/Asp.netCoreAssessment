using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Task4.Modals;

namespace Task4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ModalDbContext _dbContext;

        public EmployeeController(ModalDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet, Route("GetEmployee")]
        public ActionResult GetEmployee()
        {
            var employees = _dbContext.Employees.Include(s => s.SkillMaps).ThenInclude(s => s.Skills).Select(x => new EmployeeModal
            {
                EmployeeID = x.EmployeeID,
                Email = x.Email,
                Name = x.Name,
                Manager = x.Manager,
                Wfm_Manager = x.Wfm_Manager,
                Skills = x.SkillMaps.Select(y => y.Skills.Name).ToList()
            }).ToList();

            return new OkObjectResult(employees);
        }

        [HttpGet, Route("GetSkills")]
        public ActionResult GetSkills()
        {
            var skills = _dbContext.Skills.Include(s => s.SkillMaps).ThenInclude(s => s.Employees).ToList();

            return new OkObjectResult(skills);
        }

    }
}