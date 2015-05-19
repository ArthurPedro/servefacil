using ServeFacil.Dominio.Entidades;
using ServeFacil.Dominio.Interfaces.Servicos;
using ServeFacil.Aplicacao.Interfaces;

namespace ServeFacil.Aplicacao.Apps
{
    public class AppPortifolioServico: AppServicoBase<Portifolio>, IAppPortifolioServico
    {
        private readonly IPortifolioServico _portifolioServico;

        public AppPortifolioServico(IPortifolioServico servico)
            : base(servico)
        {
            this._portifolioServico = servico;
        }
    }
}
