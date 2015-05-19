using ServeFacil.Dominio.Entidades;
using ServeFacil.Dominio.Interfaces;
using ServeFacil.Dominio.Interfaces.Servicos;
using ServeFacil.Dominio.Interfaces.Repositorios;

namespace ServeFacil.Dominio.Servicos
{
    public class PlanoServico: ServicoBase<Plano>, IPlanoServico
    {
         private readonly IPlanosRepositorio _planoRepositorio;
        public PlanoServico(IPlanosRepositorio repositorio)
            : base(repositorio)
        {
            this._planoRepositorio = repositorio;
        }
    }
}
