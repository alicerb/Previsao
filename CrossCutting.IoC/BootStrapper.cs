
using DAL.Interfaces;
using PrevisaoTempo.Application;
using PrevisaoTempo.Application.Interfaces;
using PrevisaoTempo.DAL.Context;
using PrevisaoTempo.DAL.Repository;
using PrevisaoTempo.DAL.UoW;
using PrevisaoTempo.Domain.Interfaces.Repository;
using PrevisaoTempo.Domain.Interfaces.Service;
using PrevisaoTempo.Domain.Services;
using SimpleInjector;

namespace PrevisaoTempo.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            // App
            container.Register<ICidadeAppService, CidadeAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<ICidadeService, CidadeService>(Lifestyle.Scoped);

            // Infra Dados
            container.Register<ICidadeRepository, CidadeRepository>(Lifestyle.Scoped);
            
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<PrevisaoTempoContext>(Lifestyle.Scoped);
            //container.Register(typeof (IRepository<>), typeof (Repository<>));

            
        }
    }
}