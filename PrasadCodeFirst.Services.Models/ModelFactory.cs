using PrasadCodeFirst.Data.Models.Company;
using PrasadCodeFirst.Services.Models.Company;
using AutoMapper;
using System.Collections.Generic;

namespace PrasadCodeFirst.Services.Models
{
    public class ModelFactory
    {
        #region Employer

        public Employer Create(EmployerModel model)
        {
            return Mapper.Map<EmployerModel, Employer>(model);
        }

        public EmployerModel Create(Employer employee)
        {
            return Mapper.Map<Employer, EmployerModel>(employee);
        }

        public List<EmployerModel> Create(List<Employer> employers)
        {
            return Mapper.Map<List<Employer>, List<EmployerModel>>(employers);
        }
        #endregion

        #region Employee

        public Employee Create(EmployeeModel employee)
        {
            return Mapper.Map<EmployeeModel, Employee>(employee);
        }

        public EmployeeModel Create(Employee employee)
        {
            return Mapper.Map<Employee, EmployeeModel>(employee);
        }

        public List<EmployeeModel> Create(List<Employee> employers)
        {
            return Mapper.Map<List<Employee>, List<EmployeeModel>>(employers);
        }

        #endregion
    }
}