using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServeFacil.Dominio.Entidades;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace ServeFacil.Infra.EntityConfig
{
    public class PortPromovidosConfiguration : EntityTypeConfiguration<PortifolioPromovido>
    {
        public PortPromovidosConfiguration()
        {
            HasKey(u => u.portPromovidosId);                     
        }
    }
}
