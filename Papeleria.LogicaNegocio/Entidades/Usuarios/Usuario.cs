using Papeleria.LogicaNegocio.Excepciones.UsuarioException;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocio.ValueObjects.VO.VOUsuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades.Usuarios
{
    public class Usuario 
    {
        [Key]
        public int Id { get; set; }
        [Column("Email")]
        public Correo Emaill { get; set; }
        public PasswordUsuarioVO Passwordd { get; set; }
        public NombreApellidoVO NombreApellido { get; set; }
        public Rol Rol { get; set; }

        public Usuario() { }

        
        

    }
}
