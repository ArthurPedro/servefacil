using ServeFacil.Dominio.Entidades;
using ServeFacil.Dominio.Interfaces.Servicos;
using ServeFacil.Aplicacao.Interfaces;

namespace ServeFacil.Aplicacao.Apps
{
    public class AppPortifolioPromovidoServico: AppServicoBase<PortifolioPromovido>, IAppPortifolioPromovidoServico
    {
        private readonly IPortifolioPromovidoServico _portifolioPromovidoServico;

        public AppPortifolioPromovidoServico(IPortifolioPromovidoServico servico)
            : base(servico)
        {
            this._portifolioPromovidoServico = servico;

        }
    }
}
