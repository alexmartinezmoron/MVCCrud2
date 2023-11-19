using MVCCrud2.Models;
using MVCCrud2.Repositories;
using MVCCrud2.Models;


namespace MVCCrud2.Repositories
{
    public interface IMarcaRepository : IRepository<Marca>
    {        
        Datatable<Marca> List(string pattern, int orderColumn, string orderDir, int start, int length);        
    }
}
