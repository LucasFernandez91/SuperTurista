using SuperTurista.Core.Core;
using SuperTurista.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTurista.Core.Models
{
    public class SystemParameters : EntityBase, IEntityBase
    {
        public string Code { get; set; }
        public string Value { get; set; }
        public bool CanAccessAnon { get; set; }
        public string Comment { get; set; }
    }
}
