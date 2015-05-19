using System.Data.Entity.ModelConfiguration;
using ServeFacil.Dominio.Entidades;

namespace ServeFacil.Infra.EntityConfig 
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(u => u.UsuarioId);                            
        }
    }
}
