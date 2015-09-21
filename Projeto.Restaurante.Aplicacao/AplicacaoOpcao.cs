using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;

namespace Projeto.Restaurante.Aplicacao
{
    public class AplicacaoOpcao : AplicacaoBase<Opcao>, IAplicacaoOpcao
    {
        private readonly IServicoOpcao _servicoOpcao;

        public AplicacaoOpcao(IServicoOpcao servicoOpcao)
            : base(servicoOpcao)
        {
            _servicoOpcao = servicoOpcao;
        }
    }
}
