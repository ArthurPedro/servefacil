using ServeFacil.Dominio.Entidades;
using ServeFacil.Dominio.Interfaces.Servicos;

namespace ServeFacil.Aplicacao.Apps
{
   public interface IAppUsuarioServico : IServicoBase<Usuario>
   {
       Usuario RecuperarPorLogin(Usuario usuario);
   }
}
