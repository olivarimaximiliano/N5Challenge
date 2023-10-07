using System.ComponentModel.DataAnnotations.Schema;

namespace N5Challenge.Domain.Models
{
    [Table("Permisos")]
    public class Permission : DataEntity
    {
        [Column("NombreEmpleado")]
        public string Name { get; set; }

        [Column("ApellidoEmpleado")]
        public string Surname { get; set; }

        [ForeignKey("TipoPermiso")]
        public virtual PermissionType PermissionType { get; set; }

        [Column("FechaPermiso", TypeName = "datetime")]
        public DateTime Date { get; set; }
    }
}