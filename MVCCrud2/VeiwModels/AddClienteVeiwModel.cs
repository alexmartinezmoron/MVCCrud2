using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCCrud2.VeiwModels
{
    public class AddClienteVeiwModel
    {
        public Models.Cliente Cliente { get; set; }

        public int Id { get; set; }

        [DisplayName("Nombre:")]
        public string Nombre { get; set; } = null!;

        [DisplayName("Apellidos:")]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = "Debe indicar un correo electronico")]
        [DisplayName("Correo electrónico:")]
        public string Email { get; set; } = null!;

        [DisplayName("Contraseña:")]
        public string pass { get; set; } = null!;
    }
}
