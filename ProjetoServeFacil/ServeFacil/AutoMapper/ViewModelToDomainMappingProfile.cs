using AutoMapper;
using ServeFacil.Dominio.Entidades;
using ServeFacil.ViewModels;

namespace ServeFacil.AutoMapper
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Usuario, UsuarioViewModel>();
            Mapper.CreateMap<Categoria, CategoriaViewModel>();
            Mapper.CreateMap<Plano, PlanoViewModel>();
            Mapper.CreateMap<Portifolio, PortifolioViewModel>();
            Mapper.CreateMap<PortifolioPromovido, PortifolioPromovidoViewModel>();
            Mapper.CreateMap<Imagen, ImagensViewModel>();
       
        }
    }
}