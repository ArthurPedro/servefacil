using ServeFacil.Dominio.Entidades;
using ServeFacil.Dominio.Interfaces;
using ServeFacil.Dominio.Interfaces.Servicos;
using ServeFacil.Dominio.Interfaces.Repositorios;

namespace ServeFacil.Dominio.Servicos
{
    public class CategoriaServico : ServicoBase<Categoria>,ICategoriaServico
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        public CategoriaServico(ICategoriaRepositorio repositorio)
            : base(repositorio)
        {
            this._categoriaRepositorio = repositorio;
        }
    }
}
