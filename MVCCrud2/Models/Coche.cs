namespace MVCCrud2.Models
{
    public class Coche
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Modelo { get; set; }
 
        public string Color { get; set; }

        //Relaciones
        public Marca marca { get; set; } = null!;

    }
}
