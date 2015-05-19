using System;
using System.ComponentModel.DataAnnotations;

namespace ServeFacil.ViewModels
{
    public class PlanoViewModel
    {
        [Key]
        public int planosId { get; set; }
        public string tipo { get; set; }
        public int duracao { get; set; }
        public double valorPlano { get; set; }  
    }
}