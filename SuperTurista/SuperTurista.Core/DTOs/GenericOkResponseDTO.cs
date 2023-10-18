using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTurista.Core.DTOs
{
    public class GenericOkResponseDto
    {
        public bool Success { get; set; }
        public object Result { get; set; }
        public string UpdatedToken { get; set; }
    }
}
