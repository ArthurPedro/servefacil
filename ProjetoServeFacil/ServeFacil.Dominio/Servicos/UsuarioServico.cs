using ServeFacil.Dominio.Entidades;
using ServeFacil.Dominio.Interfaces;
using ServeFacil.Dominio.Interfaces.Servicos;

namespace ServeFacil.Dominio.Servicos
{
   public class UsuarioServico : ServicoBase<Usuario>, IUsuarioServico
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio repositorio)
            : base(repositorio)
        {
            this.usuarioRepositorio = repositorio;
        }

        public Usuario RecuperarPorLogin(Usuario usuario)
        {

            return this.usuarioRepositorio.RecuperarPorLogin(usuario);

        }
   }
}