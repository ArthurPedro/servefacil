using AutoMapper;
using ServeFacil.Dominio.Entidades;
using ServeFacil.ViewModels;

namespace ServeFacil.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<UsuarioViewModel,Usuario>();
            Mapper.CreateMap<CategoriaViewModel,Categoria>();
            Mapper.CreateMap<PlanoViewModel, Plano>();
            Mapper.CreateMap<PortifolioViewModel, Portifolio>();
            Mapper.CreateMap<PortifolioPromovidoViewModel, PortifolioPromovido>();
            Mapper.CreateMap<ImagensViewModel, Imagen>();

          
        }
    }
}