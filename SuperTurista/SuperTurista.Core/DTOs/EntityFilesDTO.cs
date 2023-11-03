using SuperTurista.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTurista.Core.DTOs
{
    public class EntityFilesDTO : EntityFiles
    {
        
    }
    public class SaveEntityFilesDTO
    {
        public long Id { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
        public string FileName { get; set; }
    }
}
