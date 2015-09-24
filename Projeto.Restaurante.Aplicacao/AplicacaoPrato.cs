using System.Collections.Generic;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;

namespace Projeto.Restaurante.Aplicacao
{
    public class AplicacaoPrato : AplicacaoBase<Prato>, IAplicacaoPrato
    {
        private readonly IServicoPrato _servicoPrato;

        public AplicacaoPrato(IServicoPrato servicoPrato)
            : base(servicoPrato)
        {
            _servicoPrato = servicoPrato;
        }

        public IEnumerable<Prato> Listar(Categoria categoria)
        {
            return _servicoPrato.Listar(categoria);
        }
    }
}
