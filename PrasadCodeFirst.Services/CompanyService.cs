using PrasadCodeFirst.Data.CommandQuery.Interfaces.Company;
using PrasadCodeFirst.Services.Interfaces;
using PrasadCodeFirst.Services.Models;
using PrasadCodeFirst.Services.Models.Company;
using AutoMapper;
using log4net;
using System;
using System.Threading.Tasks;

namespace PrasadCodeFirst.Services
{
    public class CompanyService : BaseService, ICompanyService
    {
        public CompanyService(ILog logger, IMappingEngine mappingEngine, ModelFactory modelFactory, ICompanyRepository CompanyRepository)
            : base(logger, mappingEngine, modelFactory, CompanyRepository)
        {
        }

        #region Employer

        public async Task<Guid> CreateEmployer(EmployerModel employerModel)
        {
            var employer = ModelFactory.Create(employerModel);
            employer = await CompanyRepository.EmployerRepository.AddAsync(employer);
            return employer.Id;
        }

        public async Task UpdateEmployer(EmployerModel employerModel)
        {
            var employer = ModelFactory.Create(employerModel);
            await CompanyRepository.EmployerRepository.UpdateAsync(employer, employer.Id);
        }

        public async Task DeleteEmployer(Guid employerId)
        {
            var employer = await CompanyRepository.EmployerRepository.GetAsync(employerId);
            await CompanyRepository.EmployerRepository.DeleteAsync(employer);
        }

        public async Task<EmployerModel> GetEmployer(Guid employerId)
        {
            var employee = await CompanyRepository.EmployerRepository.GetAsync(employerId);
            return ModelFactory.Create(employee);
        }

        #endregion

        #region Employee

        public async Task<Guid> CreateEmployee(EmployeeModel employeeModel)
        {
            var employee = ModelFactory.Create(employeeModel);
            employee = await CompanyRepository.EmployeeRepository.AddAsync(employee);
            return employee.Id;
        }

        public async Task UpdateEmployee(EmployeeModel employeeModel)
        {
            var employee = ModelFactory.Create(employeeModel);
            await CompanyRepository.EmployeeRepository.UpdateAsync(employee, employee.Id);
        }

        public async Task DeleteEmployee(Guid employeeId)
        {
            var employee = await CompanyRepository.EmployeeRepository.GetAsync(employeeId);
            await CompanyRepository.EmployeeRepository.DeleteAsync(employee);
        }

        public async Task<EmployeeModel> GetEmployee(Guid employeeId)
        {
            var employee = await CompanyRepository.EmployeeRepository.GetAsync(employeeId);
            return ModelFactory.Create(employee);
        }

        #endregion
    }
}
