using HierarchicalDirectoryOfDepartments.Models.HierarhyModels;
using HierarchicalDirectoryOfDepartments.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HierarchicalDirectoryOfDepartments.API
{
    [ApiController]
    [Route("api")]
    public class HierarchyApi : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDivisionRepository _divisionRepository;

        public HierarchyApi(ICompanyRepository companyRepository,
            IDepartmentRepository departmentRepository,
            IDivisionRepository divisionRepository)
        {
            _companyRepository = companyRepository;
            _departmentRepository = departmentRepository;
            _divisionRepository = divisionRepository;
        }

        [HttpPost("Company")]
        public async Task<IActionResult> AddCompany(Company company)
        {
            await _companyRepository.AddAsync(company);
            return NoContent();
        }

        [HttpPost("Department")]
        public async Task<IActionResult> AddDepartment(Department department)
        {
            await _departmentRepository.AddAsync(department);
            return NoContent();
        }

        [HttpPost("Division")]
        public async Task<IActionResult> AddDivision(Division division)
        {
            await _divisionRepository.AddAsync(division);
            return NoContent();
        }

        [HttpDelete("Company")]
        public async Task<IActionResult> DeleteCompany(Company company)
        {
            await _companyRepository.DeleteAsync(company);
            return NoContent();
        }

        [HttpDelete("Department")]
        public async Task<IActionResult> DeleteDepartment(Department department)
        {
            await _departmentRepository.DeleteAsync(department);
            return NoContent();
        }

        [HttpDelete("Division")]
        public async Task<IActionResult> DeleteDivision(Division division)
        {
            await _divisionRepository.DeleteAsync(division);
            return NoContent();
        }

        [HttpPut("ReplaceDepartment")]
        public async Task<IActionResult> ReplaceDepartment(Guid newCompanyGuid, Guid departmentGuid)
        {
            var department = await _departmentRepository.GetAsync(departmentGuid);
            if (department == null)
                return NotFound();

            department.CompanyGUID = newCompanyGuid;
            await _departmentRepository.UpdateAsync(department);

            return NoContent();
        }

        [HttpPut("ReplaceDivision")]
        public async Task<IActionResult> ReplaceDivision(Guid newDepartmentGuid, Guid divisionGuid)
        {
            var division = await _divisionRepository.GetAsync(divisionGuid);
            if (division == null)
                return NotFound();

            division.DepartmentGUID = newDepartmentGuid;
            await _divisionRepository.UpdateAsync(division);

            return NoContent();
        }
    }
}
