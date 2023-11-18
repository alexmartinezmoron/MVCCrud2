using MVCCrud2.Models;

namespace MVCCrud2.VeiwModels
{
    public class AddCocheVeiwModel
    {
        public Coche Coche { get; set; }

        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Modelo { get; set; }

        public string Color { get; set; }


        //relaciones
        public int? MarcaId { get; set; }
        public IEnumerable<Marca> Marca { get; set; }
    }
}
