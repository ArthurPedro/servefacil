using ServeFacil.Dominio.Entidades;
using ServeFacil.Dominio.Interfaces.Servicos;

namespace ServeFacil.Aplicacao.Apps
{
   public  class AppUsuarioServico : AppServicoBase<Usuario>, IAppUsuarioServico
    {
        private readonly IUsuarioServico _userServico;

        public AppUsuarioServico(IUsuarioServico servico)
            : base(servico)
        {
            this._userServico = servico;
        }

        public Usuario RecuperarPorLogin(Usuario usuario)
        {
            return this._userServico.RecuperarPorLogin(usuario);
        }
    }
}
