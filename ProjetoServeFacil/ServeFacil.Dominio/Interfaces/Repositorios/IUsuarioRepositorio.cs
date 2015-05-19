using ServeFacil.Dominio.Entidades;
using ServeFacil.Dominio.Interfaces.Repositorios;

namespace ServeFacil.Dominio.Interfaces
{
  public  interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
      Usuario RecuperarPorLogin(Usuario usuario);
    }
}
