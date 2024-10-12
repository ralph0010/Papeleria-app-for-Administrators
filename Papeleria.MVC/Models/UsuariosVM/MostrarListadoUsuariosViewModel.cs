using System.ComponentModel;

namespace Papeleria.MVC.Models.UsuariosVM
{
    public class MostrarListadoUsuariosViewModel
    {
        [DisplayName("Email")]
        public string Email {  get; set; }
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [DisplayName("Apellido")]
        public string Apellido { get; set; }

        public MostrarListadoUsuariosViewModel() { }
    }
}
