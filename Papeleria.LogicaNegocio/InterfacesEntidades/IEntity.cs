namespace Papeleria.LogicaNegocio.InterfacesEntidades
{
    public interface IEntity <T> where T : class
    {
        //Obligar� a implentear el Id
        int Id { get; set; }
    }

}

