using PrasadCodeFirst.Data.Models.Company;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;

namespace PrasadCodeFirst.Data.EntityFramework.DbContexts
{
    public partial class PrasadCodeFirstDbContext : DbContext
    {
        public PrasadCodeFirstDbContext() : base("PcfContext")
        {
            //Configuration.AutoDetectChangesEnabled = false;
            Database.SetInitializer<PrasadCodeFirstDbContext>(null);
        }

        public virtual DbSet<Employee> Employeees { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var typesToRegister = Assembly.GetAssembly(typeof(PrasadCodeFirstDbContext)).GetTypes()
                                  .Where(type => !string.IsNullOrEmpty(type.Namespace))
                                  .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                                       && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}