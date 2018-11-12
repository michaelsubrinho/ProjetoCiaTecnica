using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCiaTecnica.Models
{
    public class Cliente
    {
        public PessoaFisica PessoaFisica { get; set; }

        public PessoaJuridica PessoaJuridica { get; set; }

        [DisplayName("CEP")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Cep { get; set; }

        [DisplayName("Logradouro")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(100, ErrorMessage = "Obrigatório inserir de 10 a 100.", MinimumLength = 10)]
        public string Logradouro { get; set; }

        [DisplayName("Numero")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Numero { get; set; }

        [DisplayName("Complemento")]
        public string Complemento { get; set; }

        [DisplayName("Bairro")]
        [StringLength(20, ErrorMessage = "Obrigatório inserir de 2 a 20.", MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Somente letras.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Bairro { get; set; }

        [DisplayName("Cidade")]
        [StringLength(20, ErrorMessage = "Obrigatório inserir de 5 a 20.", MinimumLength = 5)]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Somente letras.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Cidade { get; set; }

        [DisplayName("Uf")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Somente letras.")]
        [StringLength(2, ErrorMessage = "Obrigatório inserir 2 caracteres.", MinimumLength = 2)]
        public string Uf { get; set; }
    }
}