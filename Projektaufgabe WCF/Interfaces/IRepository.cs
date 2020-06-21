using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektaufgabe_WCF.Interfaces
{
    public interface IRepository<T>
    {
        bool Delete(T entity);

        bool Save(T entity);

        bool Update(T entity);

        List<T> GetAll();
    }
}

