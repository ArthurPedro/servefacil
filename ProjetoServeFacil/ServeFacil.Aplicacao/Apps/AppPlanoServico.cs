using ServeFacil.Dominio.Entidades;
using ServeFacil.Dominio.Interfaces.Servicos;
using ServeFacil.Aplicacao.Interfaces;


namespace ServeFacil.Aplicacao.Apps
{
    public class AppPlanoServico: AppServicoBase<Plano>, IAppPlanoServico
    {
        private readonly IPlanoServico _planoServico;

        public AppPlanoServico(IPlanoServico servico)
            : base(servico)
        {
            this._planoServico = servico;
        }
    }
}
