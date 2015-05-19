using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServeFacil.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public int categoriaId { get; set; }

        public string nomeCategoria { get; set; }
    }
}