using System;
using System.ComponentModel.DataAnnotations;

namespace ServeFacil.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        [Required]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Por Favor Informar um Nome")]
        [MaxLength(150, ErrorMessage = "O nome  deve ter no máximo 150 caracteres!")]
        [MinLength(3, ErrorMessage = "O nome deve ter no minimo 3 caracteres!")]
        public String Nome { get; set; }
        
        [MaxLength(150, ErrorMessage = "O nome  deve ter no máximo 150 caracteres!")]
        [MinLength(3, ErrorMessage = "O nome deve ter no minimo 3 caracteres!")]
        public String SobreNome { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        [MinLength(5, ErrorMessage = "Asenha deve ter no minimo 5 caracteres!")]
        public String Senha { get; set; }

        [Required(ErrorMessage = "A Confirmação deve ser igual a senha informada.")]
        [Display(Name = "Confirmar Senha")]         
        [Compare("Senha")]
        public String ConfirmarSenha { get; set; }         

        [Required(ErrorMessage="Preencha o Campo de Email")]
        [EmailAddress(ErrorMessage="Digite um email valido")]
        public String email { get; set; }
        
        [Required(ErrorMessage = "Digite o CPF")]
        public String cpf { get; set; }
        public String endereco { get; set; }
        public String numero { get; set; }
        public String cidade { get; set; }
        public String estado { get; set; }
        public String cep { get; set; }
    }
}