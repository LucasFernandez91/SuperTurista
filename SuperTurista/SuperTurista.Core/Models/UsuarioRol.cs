using SuperTurista.Core.Core;
using SuperTurista.Core.Interfaces;

namespace SuperTurista.Core.Models
{
    public class UsuarioRol : EntityBase, IEntityBase, IActiveEntity
    {
        public long UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public long RolId { get; set; }
        public Rol Rol { get; set; }
        public bool Activo {  get; set; }
    }
}
