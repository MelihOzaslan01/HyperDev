using HyperDev.Core.IUnitOfWork;
using HyperDev.Core.Models;
using HyperDev.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace HyperDev.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IUnitOfWork _unitOfWork;


        public DepartmentController(IDepartmentService departmentService, IUnitOfWork unitOfWork)
        {
            _departmentService = departmentService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var GetDepartmentList = await _departmentService.GetAllAsync();
            return View(GetDepartmentList);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Department department)
        {
            await _departmentService.AddAsync(department);
            await _unitOfWork.CommitAsync();
            return RedirectToAction("Index");
        }

    }



}
