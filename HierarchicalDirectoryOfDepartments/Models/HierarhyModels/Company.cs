using System.ComponentModel.DataAnnotations;

namespace HierarchicalDirectoryOfDepartments.Models.HierarhyModels
{
    public class Company
    {
        [Key]
        public Guid GUID { get; set; }
        public string Name { get; set; }
        public virtual List<Department> Departments { get; set; } = new();
    }
}
