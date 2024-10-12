
using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.AccesoDatos.PapeleriaCT;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.UsuarioException;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Excepciones.ArticuloException;

namespace Papeleria.AccesoDatos.RepositoriosEF
{
	public class RepositorioArticulosEF:IRepositorioArticulos 
	{
		public PapeleriaContext Contexto { get; set; }
		public RepositorioArticulosEF (PapeleriaContext contexto)
        {
            Contexto = contexto;
        }
        //Agregar un articulo a la base de datos con sus validaciones correspondientes
        public void Add(Articulo art)
        {
            ValidarCodigoNoRepetido(art.Codigo.Codigo);
            ValidarNombreNoRepetido(art.nombreArticulo.Nombre);
            Contexto.Articulos.Add(art);
            Contexto.SaveChanges();
        }
        //Elimina un articulo mediante el id y si no lo encuentra retorna una exception
        public void Remove(int id)
        {
            Articulo art = GetById(id);
            if (art == null)
            {
                throw new NullReferenceException("No se encontró ningún articulo mediante el id");
            }
            Remove(art);
        }
        //Elimina el articulo 
        public void Remove(Articulo art)
        {
            Contexto.Remove(art);
            Contexto.SaveChanges();
        }
        //Actualiza el articulo y si no encuentra el id retorna una exception
        public void Update(Articulo modificado)
        {
            Articulo art = GetById(modificado.Id);
            if(art == null)
            {
                throw new ArticuloException("No se encontró ningún articulo para modifcar");
            }
            art.Descripcion = modificado.Descripcion;
            art.nombreArticulo = modificado.nombreArticulo;
            art.Stock = modificado.Stock;
            art.Precio = modificado.Precio;
            Contexto.Articulos.Update(art);
            Contexto.SaveChanges();
        }
        //Retorna todos los articulos ordenados alfabeticamente
        public IEnumerable<Articulo> GetAll()
        {
            return Contexto.Articulos.OrderBy(a=> a.nombreArticulo.Nombre).
                ThenBy(a=> a.Descripcion);
        }
        //Retorna el articulo mediante el id
        public Articulo GetById(int id)
        {
            
            return Contexto.Articulos.Find(id);
        }
        //Si el codigo se encuentra en la base de datos retorna una Exception

        public void ValidarCodigoNoRepetido(string codigo)
        {
            if (ExisteCodigo(codigo)) 
            {
                throw new Exception("Error, ya se registró un artículo" +
                    " con el mismo código");
            }
        }
        //retorna si existe el codigo en la base de datos
        private bool ExisteCodigo(string codigo)
        {
            return Contexto.Articulos.Any(a => a.Codigo.Codigo.Equals(codigo));
        }
        //Si existe un nombre repetido en la base de datos retorna una exception
        public void ValidarNombreNoRepetido(string nombre)
        {
            if (ExisteNombre(nombre))
            {
                throw new Exception("Error ya existe un artículo con el mismo " +
                    "nombre");
            }
        }
        //Retorna si existe el nombre del articulo en la base de datos
        private bool ExisteNombre(string nombre)
        {
            return Contexto.Articulos.Any(a=> a.nombreArticulo.Nombre.Equals(nombre));
        }
        //Retorna el precio del articulo median el id
        public double GetPrecioById(int id)
        {
            Articulo articulo = GetById(id);
            return articulo.Precio;
        }
        //Retorna todos los articulos para la webApi ordenados alfabeticamente de manera ascedente
        public IEnumerable<Articulo> GetArticulosOrderByAsc()
        {
            return Contexto.Articulos.Include(a => a.nombreArticulo)
                .Include(a=> a.Codigo).OrderBy(a=> a.nombreArticulo.Nombre).
                ThenBy(a => a.Descripcion);
        }

        public void ActualizarStock(Articulo art)
        {
            Articulo articulo = GetById(art.Id);
            if (art == null)
            {
                throw new ArticuloException("No se encontró ningún articulo para modifcar");
            }
            
            articulo.Stock = art.Stock;
            
            Contexto.Articulos.Update(art);
            Contexto.SaveChanges();
        }
    }

}

