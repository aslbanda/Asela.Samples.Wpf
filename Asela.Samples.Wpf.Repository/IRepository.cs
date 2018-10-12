using Asela.Samples.Wpf.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Asela.Samples.Wpf.Repository
{
    public interface IRepository<T>
    {
        Context DataContext { get; }

        T Add(T entity);

        void Update(T entity);

        T Delete(T entity);

        IQueryable<T> GetAll();

        IQueryable<T> GetBy(Expression<Func<T, bool>> expression);

        void SaveAll();
    }
}
