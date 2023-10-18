using SuperTurista.Core.Core;
using SuperTurista.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTurista.Core.Models
{
    public class Usuario : EntityBase, IEntityBase, IActiveEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Login { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public bool Activo {  get; set; }
    }
}
