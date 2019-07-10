using DomainValidation.Interfaces.Specification;
using PrevisaoTempo.Domain.Entities;
using PrevisaoTempo.Domain.Interfaces.Repository;

namespace PrevisaoTempo.Domain.Specifications
{
    public class CidadeDevePossuirNomeUnicoSpecification : ISpecification<Cidade>
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeDevePossuirNomeUnicoSpecification(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        public bool IsSatisfiedBy(Cidade cidade)
        {
            return _cidadeRepository.ObterPorNome(cidade.Nome) == null;
        }
    }
}