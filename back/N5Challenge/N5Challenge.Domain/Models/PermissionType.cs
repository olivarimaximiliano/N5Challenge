using System.ComponentModel.DataAnnotations.Schema;

namespace N5Challenge.Domain.Models
{
    [Table("TipoPermisos")]
    public class PermissionType : DataEntity
    {
        [Column("Descripcion")]
        public string Description { get; set; }
    }
}