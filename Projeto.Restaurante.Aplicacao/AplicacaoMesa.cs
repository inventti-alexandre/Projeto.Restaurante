using System.Collections.Generic;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;

namespace Projeto.Restaurante.Aplicacao
{
    public class AplicacaoMesa : AplicacaoBase<Mesa>, IAplicacaoMesa
    {
        private readonly IServicoMesa _servicoMesa;

        public AplicacaoMesa(IServicoMesa servicoMesa)
            : base(servicoMesa)
        {
            _servicoMesa = servicoMesa;
        }

        public IEnumerable<Mesa> GetAll(bool ativo)
        {
            return _servicoMesa.GetAll(ativo);
        }
    }
}
