using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCiaTecnica.Models
{
    public class PessoaJuridica
    {
        [DisplayName("CNPJ")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Cnpj { get; set; }

        [DisplayName("Razão Social")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string RazaoSocial { get; set; }

        [DisplayName("Nome Fantasia")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string NomeFantasia { get; set; }
    }
}