using PrasadCodeFirst.Services.Interfaces;
using PrasadCodeFirst.Services.Models.Company;
using Autofac.Integration.WebApi;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace PrasadCodeFirst.Web.Controllers
{
    [AutofacControllerConfiguration]
    [RoutePrefix("api/company")]
    public class CompanyController : BaseApiController
    {
        public CompanyController(ICompanyService companyService) : base(companyService)
        {
        }

        #region Employer

        // POST api/company/Employer
        [Route("Employer")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateEmployer(EmployerModel employer)
        {
            var id = await CompanyService.CreateEmployer(employer);
            return Ok(id);
        }

        // PUT api/company/Employer
        [Route("Employer")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateEmployer(EmployerModel employer)
        {
            await CompanyService.UpdateEmployer(employer);
            return Ok("Success");
        }

        // DELETE api/company/Employer/{employerId:Guid}
        [Route("Employer/{employerId:Guid}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteEmployer(Guid employerId)
        {
            await CompanyService.DeleteEmployer(employerId);
            return Ok("Success");
        }

        // GET api/company/Employee/{employerId:Guid}
        [Route("Employer/{employerId:Guid}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetEmployer(Guid employerId)
        {
            var employee = await CompanyService.GetEmployer(employerId);
            return Ok(employee);
        }

        #endregion

        #region Employee

        // POST api/company/Employee
        [Route("Employee")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateEmployee(EmployeeModel employee)
        {
            var id = await CompanyService.CreateEmployee(employee);
            return Ok(id);
        }

        // PUT api/company/Employee
        [Route("Employee")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateEmployee(EmployeeModel employee)
        {
            await CompanyService.UpdateEmployee(employee);
            return Ok("Success");
        }

        // DELETE api/company/Employee/{employeeId:Guid}
        [Route("Employee/{employeeId:Guid}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteEmployee(Guid employeeId)
        {
            await CompanyService.DeleteEmployee(employeeId);
            return Ok("Success");
        }

        // GET api/company/Employee/{employeeId:Guid}
        [Route("Employee/{employeeId:Guid}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetEmployee(Guid employeeId)
        {
            var employee = await CompanyService.GetEmployee(employeeId);
            return Ok(employee);
        }

        #endregion
    }
}