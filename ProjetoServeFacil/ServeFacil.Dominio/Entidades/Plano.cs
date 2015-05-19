using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeFacil.Dominio.Entidades
{
    public class Plano
    {
        [Key]
        public int planosId { get; set; }
        public string tipo { get; set; }
        public int duracao { get; set; }
        public double valorPlano { get; set; }       
    }
}
