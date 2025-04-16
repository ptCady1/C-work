using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected TicketContext context;
        private  DbSet<T> dbSet { get; set; }

        public Repository(TicketContext ctx)
        {
            context = ctx;
            dbSet = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        public virtual T? Get(int id) => dbSet.Find(id);
        public virtual void Insert(T entity) => dbSet.Add(entity);
        public virtual void Update(T entity) => dbSet.Update(entity);
        public virtual void Delete(T entity) => dbSet.Remove(entity);
        public virtual void Save() => context.SaveChanges();
    }
}
