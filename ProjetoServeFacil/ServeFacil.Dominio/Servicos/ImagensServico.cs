using ServeFacil.Dominio.Entidades;
using ServeFacil.Dominio.Interfaces;
using ServeFacil.Dominio.Interfaces.Servicos;
using ServeFacil.Dominio.Interfaces.Repositorios;

namespace ServeFacil.Dominio.Servicos
{
    public class ImagensServico : ServicoBase<Imagen>, IImagenServico
    {
        private readonly IImagensRepositorio _imagenRepositorio;
        public ImagensServico(IImagensRepositorio repositorio)
            : base(repositorio)
        {
            this._imagenRepositorio = repositorio;
        }
    }
}
