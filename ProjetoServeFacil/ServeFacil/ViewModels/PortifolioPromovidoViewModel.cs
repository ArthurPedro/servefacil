using System;
using System.ComponentModel.DataAnnotations;

namespace ServeFacil.ViewModels
{
    public class PortifolioPromovidoViewModel
    {
        [Key]
        public int portPromovidosId { get; set; }
        [ScaffoldColumn(false)]
        public int planoId { get; set; }
        [ScaffoldColumn(false)]
        public int portifolioId { get; set; }

        [Required(ErrorMessage = "Por Favor Informar a data de Inicio da promoção!")]
        public DateTime dataInicio { get; set; }      
        public DateTime dataFim { get; set; }
        
    }
}