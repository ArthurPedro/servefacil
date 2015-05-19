using System.Data.SqlClient;
using System.Linq;
using ServeFacil.Dominio.Entidades;
using ServeFacil.Dominio.Interfaces.Repositorios;
using ServeFacil.Dominio.Interfaces;

namespace ServeFacil.Infra.Repositorios
{
   public class UsuarioRepositorio : RepositorioBase<Usuario> , IUsuarioRepositorio
    
    {
       public Usuario RecuperarPorLogin(Usuario usuario)
       {
           SqlParameter categoryParam = new SqlParameter("@email", usuario.email);
           SqlParameter categoryParam2 = new SqlParameter("@Senha", usuario.Senha);
           return dbContext.Database.SqlQuery<Usuario>("Usuario_RecuperaLogin @email, @Senha", categoryParam, categoryParam2).First();
       }
    }
}
