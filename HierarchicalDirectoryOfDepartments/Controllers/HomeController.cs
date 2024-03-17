using HierarchicalDirectoryOfDepartments.Models;
using HierarchicalDirectoryOfDepartments.Models.HierarhyModels;
using HierarchicalDirectoryOfDepartments.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HierarchicalDirectoryOfDepartments.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDivisionRepository _divisionRepository;

        public HomeController(ICompanyRepository companyRepository,
            IDepartmentRepository departmentRepository,
            IDivisionRepository divisionRepository)
        {
            _companyRepository = companyRepository;
            _departmentRepository = departmentRepository;
            _divisionRepository = divisionRepository;
        }

        public async Task<IActionResult> Index()
        {
            var companies = await _companyRepository.GetAllIncludedAsync();
            return View(companies);
        }

        [HttpPost("ExportXML")]
        public async Task<IActionResult> ExportXML()
        {
            var companies = await _companyRepository.GetAllIncludedAsync();
            var streamXMLFile = XMLSerializer.SerializeToXML(companies);
            return File(streamXMLFile, "application/octet-stream", "model.XML");
        }

        [HttpPost("ImportXML")]
        public async Task<IActionResult> ImportXML(IFormFile XMLFile)
        {
            List<Company> companies;
            try
            {
                companies = XMLSerializer.DeserializeFromXML(XMLFile);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            await _divisionRepository.DeleteAllAsync();
            await _departmentRepository.DeleteAllAsync();
            await _companyRepository.DeleteAllAsync();

            await _companyRepository.AddListAsync(companies);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
