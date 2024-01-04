using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicSystem.IServices
{
    public interface IGenericRepository<T> where T : class
    {
        DbSet<T> dbset();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
        T GetById(object id);
        string Insert(T obj);
        string Update(T obj);
        string Delete(object id);
        string SaveChanges(int userID = 0, T obj = null, string logType = null, string userIp = null, string workType = null);
    }
}
