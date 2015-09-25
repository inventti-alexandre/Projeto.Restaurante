using System.Collections.Generic;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;

namespace Projeto.Restaurante.Aplicacao
{
    public class AplicacaoCategoria : AplicacaoBase<Categoria>, IAplicacaoCategoria
    {
        private readonly IServicoCategoria _servicoCategoria;

        public AplicacaoCategoria(IServicoCategoria servicoCategoria)
            : base(servicoCategoria)
        {
            _servicoCategoria = servicoCategoria;
        }

        public IEnumerable<Categoria> GetAll(bool ativo)
        {
            return _servicoCategoria.GetAll(ativo);
        }
    }
}
