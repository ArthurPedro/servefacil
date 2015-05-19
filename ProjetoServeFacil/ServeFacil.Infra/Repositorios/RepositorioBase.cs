using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ServeFacil.Dominio.Interfaces.Repositorios;
using ServeFacil.Infra.Contexto;

namespace ServeFacil.Infra.Repositorios
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {
        //ESSE É UM REPOSITORIO GENERICO
        protected ServeFacilContexto dbContext = new ServeFacilContexto();


        public void Add(TEntity obj)
        {
            dbContext.Set<TEntity>().Add(obj);
            dbContext.SaveChanges();//salvar as alterações
        }

        public TEntity RecuperarPorId(int id)
        {
            return this.dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> RecuperarTodos()
        {
            return this.dbContext.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            this.dbContext.Entry(obj).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            this.dbContext.Set<TEntity>().Remove(obj);
            this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
