using System.Collections.Generic;

namespace ServeFacil.Dominio.Interfaces.Servicos
{
   public interface IServicoBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity RecuperarPorId(int id);
        IEnumerable<TEntity> RecuperarTodos();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
