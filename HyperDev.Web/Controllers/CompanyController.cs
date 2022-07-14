using HyperDev.Core.IUnitOfWork;
using HyperDev.Core.Models;
using HyperDev.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace HyperDev.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(ICompanyService companyService, IUnitOfWork unitOfWork)
        {
            _companyService = companyService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var GetCompanyList = await _companyService.GetAllAsync();
            return View(GetCompanyList);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Company company)
        {
            await _companyService.AddAsync(company);
            await _unitOfWork.CommitAsync();
            return RedirectToAction("Index");
        }
        

      

        
    }
}
