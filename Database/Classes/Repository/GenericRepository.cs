using Database.Classes.Abstract;
using Database.Context;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Database.Classes.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        public void Add(T t)
        {
            using (IsLibraryContext context = new IsLibraryContext())
            {
                context.Entry(t).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public async Task AddAsync(T t)
        {
            using (IsLibraryContext context = new IsLibraryContext())
            {
                context.Entry(t).State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        public void Delete(T t)
        {
            using (IsLibraryContext context = new IsLibraryContext())
            {
                context.Entry(t).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public async Task DeleteAsync(T t)
        {
            using (IsLibraryContext context = new IsLibraryContext())
            {
                context.Entry(t).State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public ObservableCollection<T> GetAll()
        {
            using (IsLibraryContext context = new IsLibraryContext())
            {
                return new ObservableCollection<T>(context.Set<T>().ToList());
            }
        }

        public async Task<ObservableCollection<T>> GetAllAsync()
        {
            using (IsLibraryContext context = new IsLibraryContext())
            {
                return new ObservableCollection<T>(await context.Set<T>().ToListAsync());
            }
        }

        public ObservableCollection<T> GetAllByFilter(Expression<Func<T, bool>> filter)
        {
            using (IsLibraryContext context = new IsLibraryContext())
            {
                return filter == null ? new ObservableCollection<T>(context.Set<T>().ToList()) : new ObservableCollection<T>(context.Set<T>().Where(filter).ToList());
            }
        }

        public async Task<ObservableCollection<T>> GetAllByFilterAsync(Expression<Func<T, bool>> filter)
        {
            using (IsLibraryContext context = new IsLibraryContext())
            {
                return filter == null ? new ObservableCollection<T>(await context.Set<T>().ToListAsync()) : new ObservableCollection<T>(await context.Set<T>().Where(filter).ToListAsync());
            }
        }

        public T GetById(int id)
        {
            using (IsLibraryContext context = new IsLibraryContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using (IsLibraryContext context = new IsLibraryContext())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }

        public void Update(T t)
        {
            using (IsLibraryContext context = new IsLibraryContext())
            {
                context.Entry(t).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public async Task UpdateAsync(T t)
        {
            using (IsLibraryContext context = new IsLibraryContext())
            {
                context.Entry(t).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
