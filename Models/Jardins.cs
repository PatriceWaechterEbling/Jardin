namespace Jardin.Models
{
    public class Jardins
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Emplacement { get; set; }
        public int Surface { get; set; }

        //Propriétée de navigation
        public ICollection<Aliment> Aliment { get; set; }
    }
}
