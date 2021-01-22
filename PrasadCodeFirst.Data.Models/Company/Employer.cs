using System;
using System.Collections.Generic;

namespace PrasadCodeFirst.Data.Models.Company
{
    public class Employer : EntityBase<Guid>
    {
        public Employer()
        {
            Employees = new List<Employee>();
        }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual string Email { get; set; }

        public virtual Guid UserId { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}