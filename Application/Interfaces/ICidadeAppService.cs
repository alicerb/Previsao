using PrevisaoTempo.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace PrevisaoTempo.Application.Interfaces
{
    public interface ICidadeAppService : IDisposable
    {
        CidadeViewModel Adicionar(CidadeViewModel cidadeViewModel);
        CidadeViewModel ObterPorId(int id);
        CidadeViewModel ObterPorNome(string nome);
        List<CidadeViewModel> ObterTodos();

    }
}