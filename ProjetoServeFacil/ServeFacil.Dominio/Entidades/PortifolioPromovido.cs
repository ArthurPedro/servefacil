using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServeFacil.Dominio.Entidades;
using System.ComponentModel.DataAnnotations;

namespace ServeFacil.Dominio.Entidades
{
    public class PortifolioPromovido
    {
        [Key]
        public int portPromovidosId { get; set; }                
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }

        public virtual Portifolio portifolioId { get; set; }
        public virtual Plano planoId { get; set; } 
    }    
}
