using System;
using System.ComponentModel.DataAnnotations;

namespace ServeFacil.ViewModels
{
    public class PortifolioViewModel
    {
        [Key]     
        public int usuarioId { get; set; }
        public int categoriaId { get; set; }
        [ScaffoldColumn(false)]
        public int planoId { get; set; }
        [ScaffoldColumn(false)]
        [Required(ErrorMessage="Defina um titulo do portifolio")]
        public string titulo { get; set; }
        public string descricao { get; set; }
        public DateTime dataCriacao { get; set; }
    }
}