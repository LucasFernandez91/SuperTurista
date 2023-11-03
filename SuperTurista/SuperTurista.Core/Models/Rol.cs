using SuperTurista.Core.Core;
using SuperTurista.Core.Interfaces;

namespace SuperTurista.Core.Models
{
    public class Rol : EntityBase, IEntityBase, IActiveEntity
    {
        public string? Nombre { get; set; }
        public string? Codigo { get; set; }
        public bool Activo {  get; set; }
    }
}
