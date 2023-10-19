using SuperTurista.Core.Core;
using SuperTurista.Core.Interfaces;

namespace SuperTurista.Core.Models
{
    public class Reserva : EntityBase, IEntityBase, IActiveEntity
    {
        //Alojamiento, Vehiculo ---mas cosas mas adelante
        public int Type { get; set; }
        public bool Activo { get; set; }
    }
}
