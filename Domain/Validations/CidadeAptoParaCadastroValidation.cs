using DomainValidation.Validation;
using PrevisaoTempo.Domain.Interfaces.Repository;
using PrevisaoTempo.Domain.Specifications;
using PrevisaoTempo.Domain.Entities;

namespace PrevisaoTempo.Domain.Validations
{
    public class CidadeAptoParaCadastroValidation : Validator<Cidade>
    {
        public CidadeAptoParaCadastroValidation(ICidadeRepository cidadeRepository)
        {
            var nomeDuplicado = new CidadeDevePossuirNomeUnicoSpecification(cidadeRepository);
            base.Add("nomeDuplicado", new Rule<Cidade>(nomeDuplicado, "Cidade já cadastrada!"));
            
        }
    }
}