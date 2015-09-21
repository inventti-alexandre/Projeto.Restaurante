﻿using System.Collections.Generic;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;

namespace Projeto.Restaurante.Aplicacao
{
    public class AplicacaoBase<TEntity> : IAplicacaoBase<TEntity> where TEntity : class
    {
        private readonly IServicoBase<TEntity> _servicoBase;

        public AplicacaoBase(IServicoBase<TEntity> servicoBase)
        {
            _servicoBase = servicoBase;
        }

        public void Add(TEntity obj)
        {
            _servicoBase.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _servicoBase.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _servicoBase.GetAll();
        }

        public void Update(TEntity obj)
        {
            _servicoBase.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _servicoBase.Remove(obj);
        }

        public void Dispose()
        {
            _servicoBase.Dispose();
        }
    }
}
