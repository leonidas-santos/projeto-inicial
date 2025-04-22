
using System.Text.Json;

using meu_segundo_projeto.Entidade;

using Newtonsoft.Json;

namespace meu_segundo_projeto.Repositorio
{
    public class PessoaRepositorio
    {
        List<Pessoa> _pessoas = [];
        private readonly string _caminhoBanco;
        public PessoaRepositorio(string caminhoBanco)
        {
            _caminhoBanco = Banco.BuscarCaminhoBanco("bancoPessoa");
            CarregarLista();
        }

        private void CarregarLista()
        {
            string dados = File.ReadAllText(_caminhoBanco);

            _pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(dados) ?? [];
        }

        private void Salvar()
        {
            string dados = JsonConvert.SerializeObject(_pessoas);

            File.WriteAllText(_caminhoBanco, dados);
        }

        public void Adicionar(Pessoa pessoa)
        {
            _pessoas.Add(pessoa);
            Salvar();
        }

        public void Remover(Pessoa pessoa)
        {
            _pessoas.Remove(pessoa);
            Salvar();
        }

        public Pessoa BuscarPeloCPF(string cpf)
        {
            return _pessoas
                  .FirstOrDefault(pessoa => pessoa.CPF == cpf,
                  null);
        }

        public void Atualizar(Pessoa pessoa)
        {
            Pessoa pessoaRegistrado = BuscarPeloCPF(pessoa.CPF);
            if (pessoaRegistrado is not null)
            {
                pessoaRegistrado.CPF = pessoa.CPF;
                pessoaRegistrado.Nome = pessoa.Nome;
                pessoaRegistrado.Sobrenome = pessoa.Sobrenome;
                pessoaRegistrado.DataNascimento = pessoa.DataNascimento;
                pessoaRegistrado.Altura = pessoa.Altura;
                pessoaRegistrado.Peso = pessoa.Peso;
                pessoaRegistrado.Sexo = pessoa.Sexo;
                pessoaRegistrado.TipoSanguineo = pessoa.TipoSanguineo;

                Salvar();
            }
        }

        public List<Pessoa> BuscarTodos()
        {
            return _pessoas;
        }
    }
}
