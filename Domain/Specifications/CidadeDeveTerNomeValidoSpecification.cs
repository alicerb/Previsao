using DomainValidation.Interfaces.Specification;
using Previsao.Api;
using Previsao.Api.Client;
using PrevisaoTempo.Domain.Entities;

namespace EP.CrudModalDDD.Domain.Specifications.Clientes
{
    public class CidadeDeveTerNomeValidoSpecification : ISpecification<Cidade>
    {
        public bool IsSatisfiedBy(Cidade cidade)
        {
            
            return true;
        }
    }
}