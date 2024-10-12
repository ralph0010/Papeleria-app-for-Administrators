using Papeleria.MVC.Models.UsuariosVM;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Papeleria.MVC.Models.UsuariosVM
{
    public class UsuarioViewModel
    {
        [DisplayName("Email")]
        //[EmailAddress(ErrorMessage ="Formato de Email Invalido")]
        public string Email {  get; set; }
        [DisplayName("Contraseña")]
        public string Password { get; set; }
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [DisplayName("Apellido")]
        public string Apellido { get; set; }
        public IEnumerable<RolViewModel> ? Roles { get; set; } = new List<RolViewModel>();
        [DisplayName("Rol")]
        public int RolId {  get; set; }
    }
}
