using ServeFacil.Dominio.Entidades;
using ServeFacil.Dominio.Interfaces.Servicos;
using ServeFacil.Aplicacao.Interfaces;


namespace ServeFacil.Aplicacao.Apps
{
    public class AppCategoriaServico: AppServicoBase<Categoria>, IAppCategoriaServico
    {
        private readonly ICategoriaServico _categoriaServico;

        public AppCategoriaServico(ICategoriaServico servico)
            : base(servico)
        {
            this._categoriaServico = servico;
        }
    }
}
