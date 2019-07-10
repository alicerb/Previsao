using System;
using System.Collections.Generic;
using AutoMapper;
using DAL.Interfaces;
using EP.CrudModalDDD.Application;
using PrevisaoTempo.Application.Interfaces;
using PrevisaoTempo.Application.ViewModels;
using PrevisaoTempo.Domain.Entities;
using PrevisaoTempo.Domain.Interfaces.Service;

namespace PrevisaoTempo.Application
{
    public class CidadeAppService : ApplicationService, ICidadeAppService
    {
        private readonly ICidadeService _cidadeService;

        public CidadeAppService(ICidadeService cidadeService, IUnitOfWork uow)
            : base(uow)
        {
            _cidadeService = cidadeService;
        }

        public CidadeViewModel Adicionar(CidadeViewModel cidadeViewModel)
        {
            var cidade = Mapper.Map<Cidade>(cidadeViewModel);
            
            BeginTransaction();

            var clienteReturn = _cidadeService.Adicionar(cidade);
            cidadeViewModel = Mapper.Map<CidadeViewModel>(clienteReturn);
            cidadeViewModel.Sucesso = clienteReturn.ValidationResult.IsValid;
            cidadeViewModel.Mensagem = clienteReturn.ValidationResult.Message;


            if (!clienteReturn.ValidationResult.IsValid)
            {
                // Não faz o commit
                return cidadeViewModel;
            }

            Commit();

            return cidadeViewModel;
        }

        public CidadeViewModel ObterPorId(int id)
        {
            return Mapper.Map<CidadeViewModel>(_cidadeService.ObterPorId(id));
        }

        public CidadeViewModel ObterPorNome(string nome)
        {
            return Mapper.Map<CidadeViewModel>(_cidadeService.ObterPorNome(nome));
        }
       
        public List<CidadeViewModel> ObterTodos()
        {
            return Mapper.Map<List<CidadeViewModel>>(_cidadeService.ObterTodos());
        }
        
        public void Dispose()
        {
            _cidadeService.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}