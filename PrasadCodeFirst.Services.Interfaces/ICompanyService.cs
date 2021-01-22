using PrasadCodeFirst.Services.Models.Company;
using System;
using System.Threading.Tasks;

namespace PrasadCodeFirst.Services.Interfaces
{
    public interface ICompanyService
    {
        #region Employer

        Task<Guid> CreateEmployer(EmployerModel employer);

        Task UpdateEmployer(EmployerModel employer);

        Task DeleteEmployer(Guid employerId);

        Task<EmployerModel> GetEmployer(Guid employerId);

        #endregion

        #region Employee

        Task<Guid> CreateEmployee(EmployeeModel employee);

        Task UpdateEmployee(EmployeeModel employee);

        Task DeleteEmployee(Guid employeeId);

        Task<EmployeeModel> GetEmployee(Guid employeeId);

        #endregion
    }
}