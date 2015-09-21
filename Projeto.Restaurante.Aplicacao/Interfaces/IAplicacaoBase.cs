using System;
using System.Collections.Generic;

namespace Projeto.Restaurante.Aplicacao.Interfaces
{
    public interface IAplicacaoBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
