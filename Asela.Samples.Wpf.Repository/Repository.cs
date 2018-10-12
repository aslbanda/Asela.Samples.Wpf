using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asela.Samples.Wpf.Data;
using System.Linq.Expressions;

namespace Asela.Samples.Wpf.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private Context _context;

        public Context DataContext
        {
            get
            {
                if (_context == null)
                    _context = new Context();

                return _context;
            }
        }

        public T Add(T entity)
        {
            T savedObj = DataContext.Set<T>().Add(entity);

            return savedObj;
        }

        public T Delete(T entity)
        {
            T deletedObj = DataContext.Set<T>().Remove(entity);

            return deletedObj;
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> result = DataContext.Set<T>();

            return result;
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> result = DataContext.Set<T>().Where(expression);

            return result;
        }

        public void SaveAll()
        {
            DataContext.SaveChanges();
        }

        public void Update(T entity)
        {
            DataContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
