using PrasadCodeFirst.Common;
using PrasadCodeFirst.Services.Models.CompanyValidators.Validators;
using FluentValidation.Attributes;
using System;

namespace PrasadCodeFirst.Services.Models.Company
{
    [Validator(typeof (EmployeeModelValidator))]
    public class EmployeeModel : BaseRequest<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string FileName { get; set; }

        public string FullPath { get; set; }

        public bool IsActive { get; set; }

        public int Rank { get; set; }

        public Guid EmployerId { get; set; }

        public string EmployerName { get; set; }
    }
}