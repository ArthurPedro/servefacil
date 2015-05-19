using ServeFacil.Dominio.Entidades;
using ServeFacil.Dominio.Interfaces;
using ServeFacil.Dominio.Interfaces.Servicos;
using ServeFacil.Dominio.Interfaces.Repositorios;

namespace ServeFacil.Dominio.Servicos
{
    public class PortifolioPromovidoServico: ServicoBase<PortifolioPromovido>, IPortifolioPromovidoServico
    {
         private readonly IPortPromovidosRepositorio _portifolioPromovidoRepositorio;
        public PortifolioPromovidoServico(IPortPromovidosRepositorio repositorio)
            : base(repositorio)
        {
            this._portifolioPromovidoRepositorio = repositorio;
        }
    }
}
