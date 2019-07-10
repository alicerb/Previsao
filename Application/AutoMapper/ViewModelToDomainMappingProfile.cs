using AutoMapper;
using PrevisaoTempo.Application.ViewModels;
using PrevisaoTempo.Domain.Entities;

namespace EP.CrudModalDDD.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<CidadeViewModel, Cidade>();
            
        }
    }
}