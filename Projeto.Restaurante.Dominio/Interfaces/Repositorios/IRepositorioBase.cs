using System;
using System.Collections.Generic;

namespace Projeto.Restaurante.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
