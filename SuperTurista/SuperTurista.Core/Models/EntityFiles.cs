using SuperTurista.Core.Core;
using SuperTurista.Core.Interfaces;

namespace SuperTurista.Core.Models
{
    public class EntityFiles : EntityBase, IEntityBase
    {
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
        public string FileName { get; set; }
    }
}
