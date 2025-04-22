namespace meu_segundo_projeto.Entidade
{
    public static class PessoaExtensao
    {
        public static string InformacoesPessoais(this Pessoa pessoa)
        {
            string informacoes = "";

            informacoes += "Informações Pessoais \n" +
                $"Nome: {pessoa.Nome}\n" +
                $"Sobrenome: {pessoa.Sobrenome}\n" +
                $"CPF: {pessoa.CPF}\n" +
                $"Altura: {pessoa.Altura}\n" +
                $"Sexo: {pessoa.Sexo}\n" +
                $"Tipo Sanguineo {pessoa.TipoSanguineo}\n" +
                $"Data Nascimento: {pessoa.DataNascimento:dd/MM/yyyy}\n" +
                $"Peso: {pessoa.Peso}\n";

            return informacoes;
        }
    }
}
