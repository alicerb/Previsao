using System;
using System.Collections.Generic;
using PrevisaoTempo.Domain.Entities;

namespace PrevisaoTempo.Domain.Interfaces.Service
{
    public interface ICidadeService : IDisposable
    {
        Cidade Adicionar(Cidade cliente);
        Cidade ObterPorId(int id);
        Cidade ObterPorNome(string nome);
        List<Cidade> ObterTodos();
    }
}