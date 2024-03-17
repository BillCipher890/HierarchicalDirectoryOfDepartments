using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace HierarchicalDirectoryOfDepartments.Models.HierarhyModels
{
    public class Division
    {
        [Key]
        public Guid GUID { get; set; }

        [ForeignKey(nameof(Department))]
        public Guid DepartmentGUID { get; set; }

        public string Name { get; set; }

        [XmlIgnore]
        public virtual Department Department { get; set; }
    }
}
