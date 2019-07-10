using System;
using System.Collections.Generic;
using System.Linq;
using PrevisaoTempo.Domain.Entities;
using PrevisaoTempo.Domain.Interfaces.Repository;
using PrevisaoTempo.Domain.Interfaces.Service;
using PrevisaoTempo.Domain.Validations;

namespace PrevisaoTempo.Domain.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;
        
        public CidadeService(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        public Cidade Adicionar(Cidade cidade)
        {
            if(!cidade.IsValid())
            {
                return cidade;
            }

            cidade.ValidationResult = new CidadeAptoParaCadastroValidation(_cidadeRepository).Validate(cidade);
            if (!cidade.ValidationResult.IsValid)
            {
                if(cidade.ValidationResult.Erros.Any())
                {
                    cidade.ValidationResult.Message = "Cidade já cadastrada!";
                }
                return cidade;
            }

            cidade.ValidationResult.Message = "Cidade cadastrada com sucesso :)";
            return _cidadeRepository.Adicionar(cidade);
        }

        public Cidade ObterPorId(int id)
        {
            return _cidadeRepository.ObterPorId(id);
        }

        public Cidade ObterPorNome(string nome)
        {
            return _cidadeRepository.ObterPorNome(nome);
        }

      
        public List<Cidade> ObterTodos()
        {
            return _cidadeRepository.ObterTodos().ToList();
        }
        
        public void Dispose()
        {
            _cidadeRepository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}