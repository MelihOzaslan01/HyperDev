using HyperDev.API.DTOs;
using HyperDev.Core.Models;
using HyperDev.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HyperDev.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HyperDevAPIController : ControllerBase
    {
        private readonly AppDbContext _context;


        public HyperDevAPIController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department�nfoDto>> GetDepartment(int id)
        {
            Department�nfoDto department = await _context.Departments
                .Select(x => new Department�nfoDto() { Id = x.Id, Name = x.Name, CompanyName = x.Company.Name })
                .SingleOrDefaultAsync(x => x.Id == id);

            if (department == null)
            {
                return NotFound("Bu Departmana Ula��lamad�");
            }
            return Ok(department);
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            List<Department�nfoDto> departments = await _context.Departments
                .Select(x => new Department�nfoDto() { Id = x.Id, Name = x.Name, CompanyName = x.Company.Name })
                .ToListAsync();

            if (departments == null)
                return NotFound();

            return Ok(departments);

        }
        [HttpGet("{id}")]
        public IActionResult GetDepartmentsByCompany(int id)
        {
            List<Department�nfoDto> departments = _context.Departments
                .Where(x => x.Id == id)
                .Select(x => new Department�nfoDto() { Id = x.Id, Name = x.Name, CompanyName = x.Company.Name })
                .ToList();
            return Ok(departments);


        }

        [HttpPost]
        public IActionResult GetAddCompany([FromBody] Company company)
        {
            List<Company�nfoDto> companies = _context.Companies
                .Select(x => new Company�nfoDto() { CompanyId = x.Id, CompanyName = x.Name, TotalDepartment = x.Departments.Count() })
                .ToList();
            return Ok(company);

        }

        [HttpPost]
        public IActionResult GetAddDepartment([FromBody] Department department)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_context.Companies.Find(department.CompanyId) == null)
                return NotFound("�irket Bulunamad�");

            _context.Departments.Add(department);
            _context.SaveChanges();


            return Ok("Departman Ekleme ��lemi Ba�ar�l�");

        }





    }
}