using SuperTurista.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTurista.Core.DTOs
{
    public class AlojamientoDTO : Alojamiento
    {
        
    }
    public class SaveAlojamientoDTO
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Ubicacion { get; set; }
        public string Detalle { get; set; }
        public decimal Precio { get; set; }
        public bool EsOferta { get; set; }
        public decimal PrecioOferta { get; set; }
        public int Tipo { get; set; }
        public bool Activo { get; set; }
    }
}
