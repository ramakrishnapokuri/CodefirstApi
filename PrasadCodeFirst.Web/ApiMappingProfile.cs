using PrasadCodeFirst.Data.Models.Company;
using PrasadCodeFirst.Services.Models.Company;
using AutoMapper;

namespace PrasadCodeFirst.Web
{
    public class ApiMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "PrasadCodeFirst"; }
        }

        protected override void Configure()
        {

            Mapper.CreateMap<Employer, EmployerModel>().ReverseMap();

            Mapper.CreateMap<Employee, EmployeeModel>().ReverseMap();
        }
    }
}