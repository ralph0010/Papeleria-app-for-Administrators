namespace Papeleria.LogicaNegocio.InterfacesEntidades
{
    public interface IEntity <T> where T : class
    {
        //Obligará a implentear el Id
        int Id { get; set; }
    }

}

