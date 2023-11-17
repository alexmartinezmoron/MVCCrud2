namespace MVCCrud2.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string pais { get; set;}

        // Relaciones

        public HashSet<Coche> Coches { get; set; } = new HashSet<Coche>();

    }
}
