using System.Linq;
using PrevisaoTempo.Domain.Interfaces.Repository;
using PrevisaoTempo.DAL.Context;
using PrevisaoTempo.Domain.Entities;


namespace PrevisaoTempo.DAL.Repository
{
    public class CidadeRepository : Repository<Cidade>, ICidadeRepository
    {

        public CidadeRepository(PrevisaoTempoContext context)
            : base(context)
        {
            
        }

        public Cidade ObterPorNome(string nome)
        {
            return Buscar(c => c.Nome == nome).FirstOrDefault();
        }
    }
}