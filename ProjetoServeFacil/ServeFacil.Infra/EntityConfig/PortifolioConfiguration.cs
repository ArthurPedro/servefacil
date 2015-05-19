using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using ServeFacil.Dominio.Entidades;
using System.Threading.Tasks;

namespace ServeFacil.Infra.EntityConfig
{
    public class PortifolioConfiguratio : EntityTypeConfiguration<Portifolio>
    {
        public PortifolioConfiguratio()
        {
            HasKey(u => u.portfolioId);                     
        }
    }
}
