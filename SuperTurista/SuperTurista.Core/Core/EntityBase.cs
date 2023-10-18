namespace SuperTurista.Core.Core
{
    public class EntityBase
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime LastModified {  get; set; }
        public string ModifiedUser { get; set; }
    }
}