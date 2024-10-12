using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Papeleria.MVC.Models.ClientesVM
{
    public class MostrarClientesByRazonSocialViewModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Rut")]
        public string Rut {  get; set; }
        [DisplayName("Razon Social")]
        public string RazonSocial { get; set; }
        [DisplayName("Calle")]
        public string Calle {  get; set; }
        [DisplayName("Numero")]
        public string Numero { get; set; }
        [DisplayName("Ciudad")]
        public string Ciudad { get; set; }
        [DisplayName("Distancia Desde la Papelería")]
        public double DistanciaPapeleria {  get; set; }

    }
}
