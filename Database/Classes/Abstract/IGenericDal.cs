using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Database.Classes.Abstract
{
    public interface IGenericDal<T> where T : class, new()
    {
        void Add(T t);
        void Update(T t);
        void Delete(T t);
        ObservableCollection<T> GetAll();
        T GetById(int id);
        ObservableCollection<T> GetAllByFilter(Expression<Func<T, bool>> filter);

        Task AddAsync(T t);
        Task UpdateAsync(T t);
        Task DeleteAsync(T t);
        Task<ObservableCollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<ObservableCollection<T>> GetAllByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
