using System.Collections.Generic;
using System.Linq;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Exceptions;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;

namespace Projeto.Restaurante.Dominio.Servicos
{
    public class ServicoPrato : ServicoBase<Prato>, IServicoPrato
    {
        private readonly IRepositorioPrato _repositorioPrato;

        public ServicoPrato(IRepositorioPrato repositorioPrato)
            : base(repositorioPrato)
        {
            _repositorioPrato = repositorioPrato;
        }

        /// <exception cref="MyException">Nomenclatura já Cadastrada!</exception>
        public override void Add(Prato obj)
        {
            if (_repositorioPrato.ExisteNomenclaturaInformada(obj.Nome))
                throw new MyException("Nomenclatura já Cadastrada!");

            base.Add(obj);
        }

        public override IEnumerable<Prato> GetAll()
        {
            return base.GetAll().OrderBy(x => x.Nome);
        }

        public IEnumerable<Prato> GetAll(bool ativo)
        {
            return _repositorioPrato.GetAll(ativo).OrderBy(x => x.Nome);
        }

        public IEnumerable<Prato> GetAll(int categoriaId)
        {
            return _repositorioPrato.GetAll(categoriaId).OrderBy(x => x.Nome);
        }

        public IEnumerable<Prato> GetAll(int categoriaId, bool ativo)
        {
            return _repositorioPrato.GetAll(categoriaId, ativo).OrderBy(x => x.Nome);
        }

        public IEnumerable<Prato> GetAll(int categoriaId, bool disponivel, bool ativo)
        {
            return _repositorioPrato.GetAll(categoriaId, disponivel, ativo).OrderBy(x => x.Nome);
        }

        /// <exception cref="MyException">Nomenclatura já Cadastrada!</exception>
        public override void Update(Prato obj)
        {
            if (_repositorioPrato.ExisteNomenclaturaInformada(obj.Id, obj.Nome))
                throw new MyException("Nomenclatura já Cadastrada!");

            base.Update(obj);
        }
    }
}
