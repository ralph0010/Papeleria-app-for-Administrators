using Microsoft.EntityFrameworkCore;
using Papeleria.AccesoDatos.Encriptador;
using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.AccesoDatos.PapeleriaCT;
using Papeleria.LogicaNegocio.Entidades.Usuarios;
using Papeleria.LogicaNegocio.Excepciones.UsuarioException;
using Papeleria.LogicaNegocio.ValueObjects.VO.VOUsuario;

namespace Papeleria.AccesoDatos.RepositoriosEF
{
    public class RepositorioUsuariosEF : IRepositorioUsuarios
    {
        public PapeleriaContext Contexto { get; set; }

        public RepositorioUsuariosEF(PapeleriaContext contexto)
        {
            Contexto = contexto;
        }


        //Agrega un usuario en la base de datos, en el que valida y asigna la encriptacion de la contraseña previamente
        public void Add(Usuario t)
        {
            Validar(t);
            t.Passwordd.PasswordEncriptada = EncriptadorAES.Encriptar(t.Passwordd.Password);
            Contexto.Add(t);
            Contexto.Entry(t.Rol).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            Contexto.SaveChanges();
        }
        //Retorna todos los usuarios

        public IEnumerable<Usuario> GetAll()
        {
            return Contexto.Usuarios;
        }
        //Retorna un usuario mediante el id
        public Usuario GetById(int id)
        {
            return Contexto.Usuarios.Find(id);
        }
        //No implementado
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
        //Elimina un Usuario
        public void Remove(Usuario us)
        {
            Usuario usELiminado = GetUsuarioByEmail(us.Emaill.Email);
            if (usELiminado == null)
            {
                throw new Exception("Error, no se pudo eliminar el usuario");
            }
            Contexto.Usuarios.Remove(usELiminado);
            Contexto.SaveChanges();
        }
        //Actualiza un usuario, verifica que el email esté en la base de datos
        public void Update(Usuario modificado)
        {
            if (!ExisteEmail(modificado))
            {
                throw new EmailInvalidoException("Error, el email no puede ser modificable");
            }
            Usuario usuario = GetUsuarioByEmail(modificado.Emaill.Email);

            usuario.NombreApellido.Nombre = modificado.NombreApellido.Nombre;
            usuario.NombreApellido.Apellido = modificado.NombreApellido.Apellido;
            usuario.Passwordd.Password = modificado.Passwordd.Password;
            usuario.Passwordd.PasswordEncriptada = EncriptadorAES.Encriptar(usuario.Passwordd.Password);
            Contexto.Usuarios.Update(usuario);
            Contexto.SaveChanges();

        }
        //Retorna un boolenao si el email existe en la base de datos
        public bool ExisteEmail(Usuario usuario)
        {
            bool retorno = false;
            if (Contexto.Usuarios.Any(u => u.Emaill.Email.Equals(usuario.Emaill.Email)))
            {
                retorno = true;
            }
            return retorno;
        }

        //Si el email se encuentra registrado en la base de datos retorna una exception
        public void Validar(Usuario usuario)
        {
            if (ExisteEmail(usuario))
            {
                throw new EmailInvalidoException("Error, el email ya ha sido previamente registrado, " +
                    "por favor ingrese un email distinto");
            };
        }
        //Retorna un usuario mediante el email ingresado
        public Usuario GetUsuarioByEmail(string email)
        {
            return Contexto.Usuarios.Include(u => u.Rol)
                .First(e => e.Emaill.Email.Equals(email));
        }
        //Retorna un booleano si los datos ingresados coinciden con el usuario de la base de datos
        public bool DatosSesionCorrectos(string email, string password)
        {
            return Contexto.Usuarios.Any(u => u.Emaill.Email.Equals(email) &&
                u.Passwordd.Password.Equals(password));
        }
        //Si los datos no son correctos retorna una exception, sino retorna el Usuario
        public Usuario ValidarInicioSesion(string email, string password)
        {
            if(!DatosSesionCorrectos(email, password)){
                throw new Exception("Error, Datos incorrectos");
            }
            return GetUsuarioByEmail(email);
        }
    }
}

