using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServeFacil.Dominio.Entidades;

namespace ServeFacil.Infra.EntityConfig
{
    public class ImagensConfiguration : EntityTypeConfiguration<Imagen>
    {
        public ImagensConfiguration()
        {
            HasKey(u => u.imagensId);                      
        }
    }
}
