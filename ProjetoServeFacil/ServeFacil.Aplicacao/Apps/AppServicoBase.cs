using System;
using System.Collections.Generic;
using ServeFacil.Aplicacao.Interfaces;
using ServeFacil.Dominio.Interfaces.Servicos;

namespace ServeFacil.Aplicacao.Apps
{
    public class AppServicoBase<TEntity>: IDisposable, IAppServicoBase<TEntity> where TEntity : class
    {
        private readonly IServicoBase<TEntity> repBase;

        public AppServicoBase(IServicoBase<TEntity> repositorio)
        {
            this.repBase = repositorio;
        }

        public void Add(TEntity obj)
        {
            this.repBase.Add(obj);
        }

        public TEntity RecuperarPorId(int id)
        {
            return this.repBase.RecuperarPorId(id);
        }

        public IEnumerable<TEntity> RecuperarTodos()
        {
            return this.repBase.RecuperarTodos();
        }

        public void Update(TEntity obj)
        {
            this.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            this.repBase.Remove(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
