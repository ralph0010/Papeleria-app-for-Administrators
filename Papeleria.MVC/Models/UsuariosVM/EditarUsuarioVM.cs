using System.ComponentModel;

namespace Papeleria.MVC.Models.UsuariosVM
{
    public class EditarUsuarioVM
    { 
        
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Contraseña")]
        public string Password { get; set; }
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [DisplayName("Apellido")]
        public string Apellido { get; set; }
        
        public EditarUsuarioVM() { }
        public EditarUsuarioVM(int id,string email, string password, string nombre, string apellido)
        {
            
            this.Email = email;
            this.Password = password;
            this.Nombre = nombre;
            this.Apellido = apellido;
              
            
        }
    }
}
