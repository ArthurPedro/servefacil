using System;
using System.Collections.Generic;
using ServeFacil.Dominio.Interfaces.Repositorios;
using ServeFacil.Dominio.Interfaces.Servicos;

namespace ServeFacil.Dominio.Servicos
{
     
        public class ServicoBase<TEntity>: IDisposable, IServicoBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> repBase;

        public ServicoBase(IRepositorioBase<TEntity> repositorio)
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

