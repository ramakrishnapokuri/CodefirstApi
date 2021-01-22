using PrasadCodeFirst.Data.Models.Company;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PrasadCodeFirst.Data.EntityFramework.Configurations.Company
{
    [Serializable]
    public class EmployeeMapping : EntityTypeConfiguration<Employee>
    {
        public EmployeeMapping()
        {
            ToTable("Employee", "dbo");

            HasKey(e => e.Id);

            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Name).IsRequired().HasMaxLength(100);

            Property(e => e.Description).IsOptional().HasMaxLength(1000);

            Property(e => e.Mobile).IsOptional().HasMaxLength(10);
        }
    }
}