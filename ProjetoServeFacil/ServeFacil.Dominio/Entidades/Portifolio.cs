using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeFacil.Dominio.Entidades
{
    public class Portifolio
    {
        [Key]
        public int portfolioId { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }                
        public DateTime dataCriacao { get; set; }
        public virtual Usuario usuarioId { get; set; }
        public virtual Categoria categoriaId { get; set; } 

    }
}
