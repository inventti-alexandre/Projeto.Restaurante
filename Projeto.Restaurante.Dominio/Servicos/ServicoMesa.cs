using System.Collections.Generic;
using System.Linq;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Exceptions;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;

namespace Projeto.Restaurante.Dominio.Servicos
{
    public class ServicoMesa : ServicoBase<Mesa>, IServicoMesa
    {
        private readonly IRepositorioMesa _repositorioMesa;

        public ServicoMesa(IRepositorioMesa repositorioMesa)
            : base(repositorioMesa)
        {
            _repositorioMesa = repositorioMesa;
        }

        /// <exception cref="MyException">Nomenclatura já Cadastrada!</exception>
        public override void Add(Mesa obj)
        {
            if (_repositorioMesa.ExisteNomenclaturaInformada(obj.Nome))
                throw new MyException("Nomenclatura já Cadastrada!");

            base.Add(obj);
        }

        public override IEnumerable<Mesa> GetAll()
        {
            return base.GetAll().OrderBy(x => x.Nome);
        }

        /// <exception cref="MyException">Nomenclatura já Cadastrada!</exception>
        public override void Update(Mesa obj)
        {
            if (_repositorioMesa.ExisteNomenclaturaInformada(obj.Id, obj.Nome))
                throw new MyException("Nomenclatura já Cadastrada!");

            base.Update(obj);
        }
    }
}
