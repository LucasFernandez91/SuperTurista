using SuperTurista.Core.Core;
using SuperTurista.Core.Interfaces;

namespace SuperTurista.Core.Models
{
    public class Usuario : EntityBase, IEntityBase, IActiveEntity
    {
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public bool Activo {  get; set; }
        public long PersonaId { get; set; }
        public Persona Persona { get; set; }
        public HashSet<Rol>? Roles { get; set; }
    }
}
