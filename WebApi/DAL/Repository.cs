using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.DTO;
using WebApi.Interface.Repository;

namespace WebApi.DAL
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DB _context;

        private DbSet<T> entities;
        public Repository(DB context)
        {
            _context = context;
            entities = context.Set<T>();
        }
        public void Delete(int id)
        {
            T entity = entities.SingleOrDefault(x => x.Id == id);
            entities.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public T GetByID(int id)
        {
            return entities.AsNoTracking().SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            entities.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}