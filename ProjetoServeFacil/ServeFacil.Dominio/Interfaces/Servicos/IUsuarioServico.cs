using ServeFacil.Dominio.Entidades;

namespace ServeFacil.Dominio.Interfaces.Servicos
{
   public interface IUsuarioServico : IServicoBase<Usuario>
    {
       Usuario RecuperarPorLogin(Usuario usuario);
    }
}
