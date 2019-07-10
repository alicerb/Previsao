using DomainValidation.Validation;

using EP.CrudModalDDD.Domain.Specifications.Clientes;
using PrevisaoTempo.Domain.Entities;

namespace PrevisaoTempo.Domain.Validations
{
    public class CidadeEstaConsistenteValidation : Validator<Cidade>
    {
        public CidadeEstaConsistenteValidation()
        {
            var cidadeNome = new CidadeDeveTerNomeValidoSpecification();
            base.Add("cidadeNome", new Rule<Cidade>(cidadeNome, "Cidade não existe na base do OpenWeather."));
            
        }
    }
}