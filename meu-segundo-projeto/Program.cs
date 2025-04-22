using meu_segundo_projeto.Entidade;
using meu_segundo_projeto.Servico;

namespace meu_segundo_projeto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Teste();
        }

        public static void Teste()
        {
            PessoaServico pessoaServico = new(BuscarStringConexao("bancoDados"));

            pessoaServico.Adicionar(new()
            {
                Altura = 160,
                CPF = "123.123.123-47",
                DataNascimento = new DateTime(1850, 1, 30),
                Nome = "Geremias",
                Sobrenome = "Messias",
                Peso = 42,
                Sexo = Enum.Sexo.Masculino,
                TipoSanguineo = Enum.TipoSanguineo.NaoInformado
            });

            Pessoa pessoa = pessoaServico.BuscarPeloCPF("123.123.123-45");

            Console.WriteLine(pessoa.InformacoesPessoais());
        }

        private static string BuscarStringConexao(string nomeArquivo)
        {
            string diretorioBancoDados = Path.Combine(Environment.CurrentDirectory, "BancoDeDados");

            Directory.CreateDirectory(diretorioBancoDados);

            string caminhoCompleto = Path.Combine(diretorioBancoDados, $"{nomeArquivo}.json");

            if (!Path.Exists(caminhoCompleto))
                File.Create(caminhoCompleto).Dispose();

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
