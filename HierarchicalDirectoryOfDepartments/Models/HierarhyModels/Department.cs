using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace HierarchicalDirectoryOfDepartments.Models.HierarhyModels
{
    public class Department
    {
        [Key]
        public Guid GUID { get; set; }

        [ForeignKey(nameof(Company))]
        public Guid CompanyGUID { get; set; }
        public string Name { get; set; }

        [XmlIgnore]
        public virtual Company Company { get; set; }
        public virtual List<Division> Divisions { get; set; } = new();
    }
}
