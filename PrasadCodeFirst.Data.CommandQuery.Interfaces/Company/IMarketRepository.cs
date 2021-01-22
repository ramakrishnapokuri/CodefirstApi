
namespace PrasadCodeFirst.Data.CommandQuery.Interfaces.Company
{
    public interface ICompanyRepository
    {
        IEmployerRepository EmployerRepository { get; set; }

        IEmployeeRepository EmployeeRepository { get; set; }
    }
}