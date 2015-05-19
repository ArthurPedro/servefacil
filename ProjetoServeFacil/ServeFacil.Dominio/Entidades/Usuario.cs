using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeFacil.Dominio.Entidades
{
  public  class Usuario
    {

        public int UsuarioId { get; set; }
        public String Nome { get; set; }
        public String SobreNome { get; set; }
        public String email { get; set; }
        public String Senha { get; set; }
        public String ConfirmarSenha { get; set; }
        public String cpf { get; set; }
        public String cep { get; set; }        
        public String endereco { get; set; }
        public String numero { get; set; }
        public String cidade { get; set; }
        public String estado { get; set; }       

    }
}
