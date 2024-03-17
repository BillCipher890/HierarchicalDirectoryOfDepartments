using HierarchicalDirectoryOfDepartments.Models.HierarhyModels;
using Microsoft.EntityFrameworkCore;

namespace HierarchicalDirectoryOfDepartments
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var company1Guid = Guid.NewGuid();
            var company2Guid = Guid.NewGuid();
            modelBuilder.Entity<Company>().HasData(
                    new Company { GUID = company1Guid, Name = "Company 1" },
                    new Company { GUID = company2Guid, Name = "Company 2" }
            );

            var department1Guid = Guid.NewGuid();
            var department2Guid = Guid.NewGuid();
            var department3Guid = Guid.NewGuid();
            var department4Guid = Guid.NewGuid();
            modelBuilder.Entity<Department>().HasData(
                    new Department { GUID = department1Guid, CompanyGUID = company1Guid, Name = "Department 1" },
                    new Department { GUID = department2Guid, CompanyGUID = company2Guid, Name = "Department 2" },
                    new Department { GUID = department3Guid, CompanyGUID = company1Guid, Name = "Department 3" },
                    new Department { GUID = department4Guid, CompanyGUID = company2Guid, Name = "Department 4" }
            );

            var division1Guid = Guid.NewGuid();
            var division2Guid = Guid.NewGuid();
            var division3Guid = Guid.NewGuid();
            var division4Guid = Guid.NewGuid();
            var division5Guid = Guid.NewGuid();
            var division6Guid = Guid.NewGuid();
            var division7Guid = Guid.NewGuid();
            var division8Guid = Guid.NewGuid();
            modelBuilder.Entity<Division>().HasData(
                    new Division { GUID = division1Guid, DepartmentGUID = department1Guid, Name = "Division 1" },
                    new Division { GUID = division2Guid, DepartmentGUID = department1Guid, Name = "Division 2" },
                    new Division { GUID = division3Guid, DepartmentGUID = department2Guid, Name = "Division 3" },
                    new Division { GUID = division4Guid, DepartmentGUID = department2Guid, Name = "Division 4" },
                    new Division { GUID = division5Guid, DepartmentGUID = department3Guid, Name = "Division 5" },
                    new Division { GUID = division6Guid, DepartmentGUID = department3Guid, Name = "Division 6" },
                    new Division { GUID = division7Guid, DepartmentGUID = department4Guid, Name = "Division 7" },
                    new Division { GUID = division8Guid, DepartmentGUID = department4Guid, Name = "Division 8" }
            );
        }
    }
}
