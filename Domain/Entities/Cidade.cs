using DomainValidation.Validation;
using PrevisaoTempo.Domain.Validations;

namespace PrevisaoTempo.Domain.Entities
{
    public class Cidade
    {
        public Cidade()
        {
            
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int OpenWeatherId { get; set; }
        
        public ValidationResult ValidationResult { get; set; }
        
        public bool IsValid()
        {
            ValidationResult = new CidadeEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}