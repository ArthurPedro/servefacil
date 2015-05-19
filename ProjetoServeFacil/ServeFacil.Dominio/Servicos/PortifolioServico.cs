using ServeFacil.Dominio.Entidades;
using ServeFacil.Dominio.Interfaces;
using ServeFacil.Dominio.Interfaces.Servicos;
using ServeFacil.Dominio.Interfaces.Repositorios;

namespace ServeFacil.Dominio.Servicos
{
    public class PortifolioServico: ServicoBase<Portifolio>, IPortifolioServico
    {
         private readonly IPortifolioRepositorio _portifolioRepositorio;
        public PortifolioServico(IPortifolioRepositorio repositorio)
            : base(repositorio)
        {
            this._portifolioRepositorio = repositorio;
        }    
    }
}
