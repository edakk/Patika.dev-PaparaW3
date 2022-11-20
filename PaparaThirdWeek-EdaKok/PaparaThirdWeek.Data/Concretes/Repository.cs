using Microsoft.EntityFrameworkCore;
using PaparaThirdWeek.Data.Abstracts;
using PaparaThirdWeek.Data.Context;
using PaparaThirdWeek.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaparaThirdWeek.Data.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public AppDbContext Context { get; }
        public Repository(AppDbContext context)
        {
            Context = context;
        }
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();

        }

        public IQueryable<T> Get()
        {
            return Context.Set<T>()
                .Where(x => !x.IsDeleted)
                .AsQueryable();

        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>()
                .Where(expression)
                .AsQueryable();
        }

        public void HardRemove(T entity)
        {
            T existData = Context.Set<T>().Find(entity.Id);
            if (existData != null)
            {
                Context.Set<T>().Remove(existData);
                Context.SaveChanges();
            }
        }

        public void Remove(T entity)
        {
            T existData = Context.Set<T>().Find(entity.Id);
            if (existData != null)
            {
                existData.IsDeleted = true;
                Context.Entry(existData).State = EntityState.Modified;
                Context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
