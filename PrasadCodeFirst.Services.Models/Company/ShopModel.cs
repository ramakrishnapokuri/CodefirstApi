using PrasadCodeFirst.Services.Models.CompanyValidators.Validators;
using FluentValidation.Attributes;
using System;

namespace PrasadCodeFirst.Services.Models.Company
{
    [Validator(typeof (EmployerModelValidator))]
    public class EmployerModel : BaseRequest<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public Guid UserId { get; set; }
    }
}