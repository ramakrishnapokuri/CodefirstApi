using PrasadCodeFirst.Data.CommandQuery.Interfaces.Company;

namespace PrasadCodeFirst.Data.CommandQuery.Company
{
    public class CompanyRepository : ICompanyRepository
    {
        public IEmployerRepository EmployerRepository { get; set; }

        public IEmployeeRepository EmployeeRepository { get; set; }

    }
}