using AutoMapper;
using PrevisaoTempo.Application.ViewModels;
using PrevisaoTempo.Domain.Entities;

namespace EP.CrudModalDDD.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Cidade, CidadeViewModel>();
           
        }
    }
}