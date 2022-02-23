using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
   public interface IRepository<T> where T:class
    {
        T Get(int Id);
        
        IEnumerable<T> GetAll();

        bool Add(T entity);

        bool Remove(T entity);

        bool Save();
    }
}
