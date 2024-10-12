
using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.LogicaNegocio.Entidades.Usuarios;

namespace Papeleria.AccesoDatos.InterfacesRepositorios
{
	public interface IRepositorioUsuarios : IRepositorio<Usuario>
	{
        //Verifica si el email se encuentra en la base de datos
        bool ExisteEmail(Usuario usuario);
        //Valida datos del usuario
        void Validar(Usuario usuario);
        //Retorna el usuario median el email
        Usuario GetUsuarioByEmail(string email);
        //Retorna si los datos son correctos
        bool DatosSesionCorrectos(string email, string password);
        //Si los datos ingresados son correctos retorna el Usuario
        Usuario ValidarInicioSesion(string email, string password);

    }

}

