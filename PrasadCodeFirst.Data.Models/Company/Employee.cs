using System;

namespace PrasadCodeFirst.Data.Models.Company
{
    public class Employee : EntityBase<Guid>
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual string Email { get; set; }

        public virtual string Mobile { get; set; }

        public virtual string FileName { get; set; }

        public virtual string FullPath { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual int Rank { get; set; }

        public virtual Guid EmployerId { get; set; }

        public virtual Employer Employer { get; set; }
    }
}