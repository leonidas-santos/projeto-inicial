using System.Reflection.Metadata.Ecma335;


namespace meu_primeiro_projeto.Estacionamento.Entidade
{
    public class Veiculo
    {
        public Guid Id { get; set; }
        public int Rodas { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime DataHoraSaida { get; set; }
    }
}
