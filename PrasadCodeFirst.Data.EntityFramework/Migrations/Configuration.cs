using System.Data.Entity.Migrations;
using System.Linq;
using PrasadCodeFirst.Data.EntityFramework.DbContexts;

namespace PrasadCodeFirst.Data.EntityFramework.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<PrasadCodeFirstDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations";
        }

        protected override void Seed(PrasadCodeFirstDbContext context)
        {
            var isSeededAlready = context.Employers.Any();
            if (isSeededAlready) return;
        }
    }
}