namespace Jardin.Models
{
    public class Aliment
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        //Propriétée de navigation
        public ICollection<Jardins> Jardins { get; set; }
    }
}
