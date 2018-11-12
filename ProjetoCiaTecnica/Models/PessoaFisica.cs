using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCiaTecnica.Models
{
    public class PessoaFisica
    {
        [DisplayName("CPF")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DataType(DataType.Date)]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [StringLength(12, ErrorMessage = "O limite é de 12 caracteres.", MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Somente letras.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [StringLength(15, ErrorMessage = "O limite é de 15 caracteres.", MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Somente letras.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Sobrenome")]
        public string Sobrenome { get; set; }
    }
}