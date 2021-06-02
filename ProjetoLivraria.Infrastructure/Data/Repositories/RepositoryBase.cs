using Microsoft.EntityFrameworkCore;
using ProjetoLivraria.Domain.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoLivraria.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SQLContext sqlcontext;

        public RepositoryBase(SQLContext sqlcontext)
        {
            this.sqlcontext = sqlcontext;
        }

        public void Add(TEntity obj)
        {
            try
            {
                sqlcontext.Set<TEntity>().Add(obj);
                sqlcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return sqlcontext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return sqlcontext.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            try
            {
                sqlcontext.Set<TEntity>().Remove(obj);
                sqlcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TEntity obj)
        {
            try
            {
                sqlcontext.Entry(obj).State = EntityState.Modified;
                sqlcontext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
