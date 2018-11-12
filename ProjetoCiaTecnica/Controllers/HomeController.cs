using ProjetoCiaTecnica.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace ProjetoCiaTecnica.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult CadastrarPessoa()
        {
            Cliente pessoa = new Cliente();
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult CadastrarPessoa(Cliente pessoa)
        {
            if (!ModelState.IsValid)
            {
                return View(pessoa);
            }

            if (pessoa.PessoaFisica != null && (DateTime.Now.Year - pessoa.PessoaFisica.DataNascimento.Year) < 19)
            {
                ModelState.AddModelError("idade-invalida", "Não é permitido cadastro para menores de 19 anos.");
                return View(pessoa);
            }

            string strConnection = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(strConnection);

            SqlCommand sqlCommand = null;


            if (pessoa.PessoaJuridica == null)
            {
                sqlCommand = new SqlCommand("INSERT INTO PESSOA_FISICA (CPF, DATA_NASCIMENTO, NOME, SOBRENOME, CEP, LOGRADOURO, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, UF)" +
                " VALUES (@CPF, @DATA_NASCIMENTO, @NOME, @SOBRENOME, @CEP, @LOGRADOURO, @NUMERO, @COMPLEMENTO, @BAIRRO, @CIDADE, @UF)", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@CPF", pessoa.PessoaFisica.Cpf);
                sqlCommand.Parameters.AddWithValue("@NOME", pessoa.PessoaFisica.Nome);
                sqlCommand.Parameters.AddWithValue("@SOBRENOME", pessoa.PessoaFisica.Sobrenome);
                sqlCommand.Parameters.AddWithValue("@DATA_NASCIMENTO", pessoa.PessoaFisica.DataNascimento);
                sqlCommand.Parameters.AddWithValue("@CEP", pessoa.Cep);
                sqlCommand.Parameters.AddWithValue("@LOGRADOURO", pessoa.Logradouro);
                sqlCommand.Parameters.AddWithValue("@NUMERO", pessoa.Numero);
                sqlCommand.Parameters.AddWithValue("@COMPLEMENTO", pessoa.Complemento ?? (object)DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@BAIRRO", pessoa.Bairro);
                sqlCommand.Parameters.AddWithValue("@CIDADE", pessoa.Cidade);
                sqlCommand.Parameters.AddWithValue("@UF", pessoa.Uf);
            }
            else
            {
                sqlCommand = new SqlCommand("INSERT INTO PESSOA_JURIDICA (CNPJ, NOME_FANTASIA, RAZAO_SOCIAL, CEP, LOGRADOURO, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, UF)" +
                " VALUES (@CNPJ, @NOME_FANTASIA, @RAZAO_SOCIAL, @CEP, @LOGRADOURO, @NUMERO, @COMPLEMENTO, @BAIRRO, @CIDADE, @UF)", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@CNPJ", pessoa.PessoaJuridica.Cnpj);
                sqlCommand.Parameters.AddWithValue("@NOME_FANTASIA", pessoa.PessoaJuridica.NomeFantasia);
                sqlCommand.Parameters.AddWithValue("@RAZAO_SOCIAL", pessoa.PessoaJuridica.RazaoSocial);
                sqlCommand.Parameters.AddWithValue("@CEP", pessoa.Cep);
                sqlCommand.Parameters.AddWithValue("@LOGRADOURO", pessoa.Logradouro);
                sqlCommand.Parameters.AddWithValue("@NUMERO", pessoa.Numero);
                sqlCommand.Parameters.AddWithValue("@COMPLEMENTO", pessoa.Complemento);
                sqlCommand.Parameters.AddWithValue("@BAIRRO", pessoa.Bairro);
                sqlCommand.Parameters.AddWithValue("@CIDADE", pessoa.Cidade);
                sqlCommand.Parameters.AddWithValue("@UF", pessoa.Uf);
            }

            sqlCommand.CommandType = System.Data.CommandType.Text;

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("erro-cadastrar", ex.Message);
                return View(pessoa);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}