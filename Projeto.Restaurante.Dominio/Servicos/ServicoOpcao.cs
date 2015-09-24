using System.Collections.Generic;
using System.Linq;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Exceptions;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;

namespace Projeto.Restaurante.Dominio.Servicos
{
    public class ServicoOpcao : ServicoBase<Opcao>, IServicoOpcao
    {
        private readonly IRepositorioOpcao _repositorioOpcao;

        public ServicoOpcao(IRepositorioOpcao repositorioOpcao)
            : base(repositorioOpcao)
        {
            _repositorioOpcao = repositorioOpcao;
        }

        /// <exception cref="MyException">Nomenclatura já Cadastrada!</exception>
        public override void Add(Opcao obj)
        {
            if (_repositorioOpcao.ExisteNomenclaturaInformada(obj.Nome))
                throw new MyException("Nomenclatura já Cadastrada!");

            base.Add(obj);
        }

        public override IEnumerable<Opcao> GetAll()
        {
            return base.GetAll().OrderBy(x => x.Nome);
        }

        /// <exception cref="MyException">Nomenclatura já Cadastrada!</exception>
        public override void Update(Opcao obj)
        {
            if (_repositorioOpcao.ExisteNomenclaturaInformada(obj.Id, obj.Nome))
                throw new MyException("Nomenclatura já Cadastrada!");

            base.Update(obj);
        }
    }
}
