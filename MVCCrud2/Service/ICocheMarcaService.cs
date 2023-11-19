using MVCCrud2.Models;

namespace MVCCrud2.Service
{
    public class ICocheMarcaService
    {
        string List(DatatableOptions options);
        IEnumerable<Marca> List();
        bool Add(Marca marca);
        bool Update(Marca marca);
        bool Remove(Marca marca);
        Marca GetById(int id);
    }
}
