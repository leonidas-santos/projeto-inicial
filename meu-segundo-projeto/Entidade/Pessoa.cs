

using meu_segundo_projeto.Enum;

namespace meu_segundo_projeto.Entidade
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public Sexo Sexo { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
    }
}
