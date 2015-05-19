using System;
using System.ComponentModel.DataAnnotations;


namespace ServeFacil.ViewModels
{
    public class ImagensViewModel
    {
        [Key]
        public int imagensId { get; set; }
        [ScaffoldColumn(false)]
        public int usuarioId { get; set; }
        [ScaffoldColumn(false)]
        public int portId { get; set; }
        [ScaffoldColumn(false)]
        public string caminho { get; set; }
    }
}