using System.Collections.Generic;
using System.Threading.Tasks;

namespace HogwartsPotions.DAL.Interfaces
{
    public interface IBaseService<T>
    {
        Task Add(T item);
        Task<List<T>> GetAll();
        Task<T> Get(long id);
        Task Update(T item);
        Task Delete(long id);
    }
}
