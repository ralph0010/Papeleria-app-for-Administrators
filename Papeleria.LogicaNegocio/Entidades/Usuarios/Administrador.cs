using Papeleria.LogicaNegocio.Entidades.Usuarios;
using Papeleria.LogicaNegocio.ValueObjects.VO.VOUsuario;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class Administrador : Rol
    {
        private int _id = 1;
        public override int Id { get => _id; set => _id = value; }
        public Administrador() : base("Administrador") { }
        
        
    }

}

