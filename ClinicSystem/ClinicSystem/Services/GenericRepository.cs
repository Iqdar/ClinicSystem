using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ClinicSystem.Models;
using ClinicSystem.IServices;

namespace ClinicSystem.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ClinicSystemContext _context = null;
        private DbSet<T> table = null;
        public GenericRepository()
        {
            this._context = new ClinicSystemContext();
            table = _context.Set<T>();
        }
        public GenericRepository(ClinicSystemContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public DbSet<T> dbset()
        {
            return table;
        }




        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return table.Where(expression);
        }

        public string Insert(T obj)
        {
            try
            {
                table.Add(obj);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "";

        }
        public string Update(T obj)
        {
            try
            {

                table.Attach(obj);
                _context.Entry(obj).State = EntityState.Modified;
                try
                {
                    _context.Entry(obj).Property("CreatedBy").IsModified = false;
                    _context.Entry(obj).Property("CreatedDate").IsModified = false;
                }
                catch { }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "";
        }


        public string Delete(object id)
        {
            try
            {
                T existing = table.Find(id);
                table.Remove(existing);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "";
        }

        public string SaveChanges(int userID = 0, T obj = null, string logType = null, string userIp = null, string workType = null)
        {
            try
            {
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "";
        }

    }
}
