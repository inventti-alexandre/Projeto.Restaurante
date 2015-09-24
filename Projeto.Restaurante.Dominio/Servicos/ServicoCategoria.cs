using System.Collections.Generic;
using System.Linq;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Exceptions;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;

namespace Projeto.Restaurante.Dominio.Servicos
{
    public class ServicoCategoria : ServicoBase<Categoria>, IServicoCategoria
    {
        private readonly IRepositorioCategoria _repositorioCategoria;

        public ServicoCategoria(IRepositorioCategoria repositorioCategoria)
            : base(repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }

        /// <exception cref="MyException">Nomenclatura já Cadastrada!</exception>
        public override void Add(Categoria obj)
        {
            if (_repositorioCategoria.ExisteNomenclaturaInformada(obj.Nome))
                throw new MyException("Nomenclatura já Cadastrada!");

            base.Add(obj);
        }

        public override IEnumerable<Categoria> GetAll()
        {
            return base.GetAll().OrderBy(x => x.Nome);
        }

        /// <exception cref="MyException">Nomenclatura já Cadastrada!</exception>
        public override void Update(Categoria obj)
        {
            if (_repositorioCategoria.ExisteNomenclaturaInformada(obj.Id, obj.Nome))
                throw new MyException("Nomenclatura já Cadastrada!");

            base.Update(obj);
        }

    }
}
