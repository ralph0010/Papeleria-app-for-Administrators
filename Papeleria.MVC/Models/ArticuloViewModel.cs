using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Papeleria.MVC.Models
{
    public class ArticuloViewModel
    {

        [DisplayName("Nombre del articulo")]
        [StringLength(200, MinimumLength = 10, ErrorMessage ="El nombre debe contener " +
            "entre 10 y 200 caracteres" )]
        public string Nombre { get; set; }
        [MinLength( 5, ErrorMessage = "La descripción debe contener mínimo 5" +
            " caracteres" )]
        [DisplayName("Descripcion del articulo")]
        
        public string Descripcion { get; set; }

        [DisplayName("Codigo")]
        [Length(13,13,ErrorMessage ="El código solo puede contener 13 caracteres")]
        public string Codigo { get; set; }

        [DisplayName("Precio")]
        [Range(0,double.MaxValue,ErrorMessage ="El precio no puede ser menor a 0")]
        public double CantPrecio { get; set; }
        [DisplayName("Stock")]
        [Range(1,int.MaxValue,ErrorMessage ="El stock no puede ser menor a " +
            "0")]
        public int Cantidad { get; set; }
      
    }
}
