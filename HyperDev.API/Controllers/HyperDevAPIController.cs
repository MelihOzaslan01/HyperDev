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
        public async Task<ActionResult<DepartmentÝnfoDto>> GetDepartment(int id)
        {
            DepartmentÝnfoDto department = await _context.Departments
                .Select(x => new DepartmentÝnfoDto() { Id = x.Id, Name = x.Name, CompanyName = x.Company.Name })
                .SingleOrDefaultAsync(x => x.Id == id);

            if (department == null)
            {
                return NotFound("Bu Departmana Ulaþýlamadý");
            }
            return Ok(department);
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            List<DepartmentÝnfoDto> departments = await _context.Departments
                .Select(x => new DepartmentÝnfoDto() { Id = x.Id, Name = x.Name, CompanyName = x.Company.Name })
                .ToListAsync();

            if (departments == null)
                return NotFound();

            return Ok(departments);

        }
        [HttpGet("{id}")]
        public IActionResult GetDepartmentsByCompany(int id)
        {
            List<DepartmentÝnfoDto> departments = _context.Departments
                .Where(x => x.Id == id)
                .Select(x => new DepartmentÝnfoDto() { Id = x.Id, Name = x.Name, CompanyName = x.Company.Name })
                .ToList();
            return Ok(departments);


        }

        [HttpPost]
        public IActionResult GetAddCompany([FromBody] Company company)
        {
            List<CompanyÝnfoDto> companies = _context.Companies
                .Select(x => new CompanyÝnfoDto() { CompanyId = x.Id, CompanyName = x.Name, TotalDepartment = x.Departments.Count() })
                .ToList();
            return Ok(company);

        }

        [HttpPost]
        public IActionResult GetAddDepartment([FromBody] Department department)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_context.Companies.Find(department.CompanyId) == null)
                return NotFound("Þirket Bulunamadý");

            _context.Departments.Add(department);
            _context.SaveChanges();


            return Ok("Departman Ekleme Ýþlemi Baþarýlý");

        }





    }
}