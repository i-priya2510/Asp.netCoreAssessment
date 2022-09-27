using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Task4.Modals;

namespace Task4.Controllers
{
    public class EmployeeViewControllers : Controller
    {
        private readonly ModalDbContext _dbContext;

        public EmployeeViewControllers(ModalDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public IActionResult Index()
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

            return View(employees);
        }
    }
}