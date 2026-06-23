namespace Dsw2026Ej15.Domain.Entities
{
    public class Speciality : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        private Speciality()
        {
            
        }
        public Speciality(Guid id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }
    }
}
