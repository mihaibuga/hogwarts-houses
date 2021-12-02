using System.Collections.Generic;
using System.Threading.Tasks;

namespace HogwartsPotions.DAL.Interfaces
{
    public interface IBaseService<T>
    {
        Task<List<T>> GetAll();
        void Add();
        void Add(T entity);
        T Get(long id);
        void Delete(long id);
        void Update(long id);
    }
}
