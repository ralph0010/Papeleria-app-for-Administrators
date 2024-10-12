using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades.Usuarios
{
    public abstract class Rol
    {
        [Key]
        public abstract int Id { get; set; }
        private string _tipoRol {  get; set; }
        public string TipoRol { get =>_tipoRol; set => _tipoRol = value; }
        public Rol() { }
        public Rol(string tipoRol)
        {
            _tipoRol = tipoRol;
        }

        
    }
}
