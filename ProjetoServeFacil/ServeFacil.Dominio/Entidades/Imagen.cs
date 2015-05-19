using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeFacil.Dominio.Entidades
{
    public class Imagen
    {
        [Key]
        public int imagensId { get; set; }
        public string caminho { get; set; }

        public virtual Usuario usuarioId { get; set; }
        public virtual Portifolio portId { get; set; } 
        

    }
}
