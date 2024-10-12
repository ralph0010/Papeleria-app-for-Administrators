using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades.Usuarios
{
    public class EncargadoDeposito : Rol
    {
        private int _id = 2;
        public override int Id { get => _id; set => _id = value; }
        public EncargadoDeposito() : base("EncargadoDeposito") { }
    }
}
