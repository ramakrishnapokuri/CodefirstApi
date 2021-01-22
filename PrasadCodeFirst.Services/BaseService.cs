using PrasadCodeFirst.Common;
using PrasadCodeFirst.Services.Models;
using AutoMapper;
using log4net;
using PrasadCodeFirst.Data.CommandQuery.Interfaces.Company;

namespace PrasadCodeFirst.Services
{
    public abstract class BaseService
    {
        protected BaseService(ILog logger, IMappingEngine mappingEngine, ModelFactory modelFactory, ICompanyRepository companyRepository)
        {
            Guard.AgainstNull(logger, "logger");
            Guard.AgainstNull(modelFactory, "modelFactory");
            Guard.AgainstNull(mappingEngine, "mappingEngine");
            Guard.AgainstNull(companyRepository, "CompanyRepository");

            Logger = logger;
            MappingEngine = mappingEngine;
            ModelFactory = modelFactory;
            CompanyRepository = companyRepository;
        }

        protected ILog Logger { get; set; }
        protected IMappingEngine MappingEngine { get; set; }
        public ModelFactory ModelFactory { get; set; }
        public ICompanyRepository CompanyRepository { get; set; }
    }
}