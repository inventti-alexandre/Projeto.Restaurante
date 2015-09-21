﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Restaurante.Dominio.Entidades
{
    public class Categoria : Base
    {
        #region Propriedades
        public string Nome { get; private set; }
        public virtual IList<Prato> Pratos { get; private set; }
        #endregion

        #region Construtores
        public Categoria()
        {
            
        }
        #endregion

        #region Preencher
        public void PreencherPratos()
        {
            Pratos = Prato.Listar(this);
        }
        public async Task PreencherPratosAsync()
        {
            await Task.Run(() => PreencherPratos());
        }
        #endregion

        #region Listar
        public static IList<Categoria> Listar()
        {
            return new List<Categoria>();
        }
        public static async Task<IList<Categoria>> ListarComPratosPreenchidosAsync()
        {
            var categorias = Listar();
            var tasks = categorias.Select(async categoria => await categoria.PreencherPratosAsync());
            await Task.WhenAll(tasks);
            return categorias;
        }
        #endregion
    }
}