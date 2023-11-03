using SuperTurista.Core.Core;
using SuperTurista.Core.Interfaces;

namespace SuperTurista.Core.Models
{
    public class Vehiculo : EntityBase, IEntityBase, IActiveEntity
    {
        public string Titulo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Detalle { get; set; }
        public decimal Precio { get; set; }
        public bool EsOferta { get; set; }
        public decimal PrecioOferta { get; set; }
        public int Tipo { get; set; }
        public bool Activo { get; set; }
        public HashSet<EntityFiles> Images { get; set; }
    }
}
