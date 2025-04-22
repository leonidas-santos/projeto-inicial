
using meu_segundo_projeto.Entidade;
using meu_segundo_projeto.Repositorio;
using meu_segundo_projeto.Servico;

namespace meu_segundo_projeto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PessoaServico pessoaServico = new(BuscarStringConexao("bancoDados"));

            Pessoa pessoaFicticia = new Pessoa()
            {
                Altura = 160,
                CPF = "123.123.123-45",
                DataNascimento = new DateTime(1850, 1, 30),
                Nome = "Matusalém",
                Sobrenome = "Messias",
                Peso = 42,
                Sexo = Enum.Sexo.Masculino,
                TipoSanguineo = Enum.TipoSanguineo.NaoInformado
            };

            pessoaServico.Adicionar(pessoaFicticia);

            Pessoa pessoa = pessoaServico.BuscarPeloCPF("123.123.123-45");

            Console.WriteLine(pessoa.InformacoesPessoais());
        }

        private static string BuscarStringConexao(string nomeArquivo)
        {
            string diretorioBancoDados = Path.Combine(Environment.CurrentDirectory, "BancoDeDados");

            Directory.CreateDirectory(diretorioBancoDados);

            string caminhoCompleto = Path.Combine(diretorioBancoDados, $"{nomeArquivo}.json");

            if (!Path.Exists(caminhoCompleto))
            {
                FileStream file = File.Create(caminhoCompleto);

                //Quando alguem abre um arquivo, ele não pode ser aberto por outra pessoa/programa
                //dessa forma precisamos fechar/encerrar o processo do arquivo.
                file.Dispose();
            }

            return caminhoCompleto;
        }
    }

















    //public class Name(string firstName, string lastName)
    //{
    //    public string FirstName => firstName;
    //    public string LastName => lastName;
    //}

    //public record Name2(string FirstName, string LastName);
}