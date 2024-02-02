using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserRegApp.Context;

namespace UserRegApp.Repositories
{
    internal class Repo<TEntity> where TEntity : class
    {
        private readonly DataContext _context;

        public Repo(DataContext context)
        {
            _context = context;
        }


        //CREATE 
        public virtual TEntity Create(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
                return entity;

            }
            catch { }
            return null!;

        }

        // READ ONE
        public virtual TEntity Read(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entity = _context.Set<TEntity>().FirstOrDefault(expression);
                return entity!;

            }
            catch { }
            return null!;

        }

        // READ ALL
        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _context.Set<TEntity>().ToList();
            }catch { }
            return null!;
      
        }

        //UPDATE
        public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
        {
            try
            {
                var entityToUpdate = _context.Set<TEntity>().FirstOrDefault(expression);
                _context.Entry(entityToUpdate!).CurrentValues.SetValues(entity);
                _context.SaveChanges();
                return entityToUpdate!;

            }
            catch { }
            return null!;
        }

        // DELETE
        public virtual bool Delete(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entity = _context.Set<TEntity>().FirstOrDefault(expression);
                _context.Remove(entity!);
                _context.SaveChanges();

            }
            catch { }
            return false!;

        }


    }
}
