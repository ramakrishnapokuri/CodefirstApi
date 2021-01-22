using PrasadCodeFirst.Common;
using PrasadCodeFirst.Services.Interfaces;
using System.Web.Http;

namespace PrasadCodeFirst.Web.Controllers
{
    public class BaseApiController : ApiController
    {
        public BaseApiController(ICompanyService companyService)
        {
            Guard.AgainstNull(companyService, "companyService");

            CompanyService = companyService;
        }

        protected ICompanyService CompanyService { get; set; }
    }
}