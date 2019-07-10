using PrevisaoTempo.Domain.Entities;

namespace PrevisaoTempo.Domain.Interfaces.Repository
{
    public interface ICidadeRepository : IRepository<Cidade>
    {
        Cidade ObterPorNome(string nome);
    }
}