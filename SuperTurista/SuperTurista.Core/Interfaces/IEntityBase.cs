using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTurista.Core.Interfaces
{
    public interface IEntityBase
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedUser { get; set; }
    }
}
