using ServeFacil.Dominio.Entidades;
using ServeFacil.Dominio.Interfaces.Servicos;
using ServeFacil.Aplicacao.Interfaces;


namespace ServeFacil.Aplicacao.Apps
{
    public class AppImagenServico: AppServicoBase<Imagen>, IAppImagenServico
    {
        private readonly IImagenServico _imagenServico;

        public AppImagenServico(IImagenServico servico)
            : base(servico)
        {
            this._imagenServico = servico;
        }
    }
}
