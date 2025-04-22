using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meu_primeiro_projeto.Estacionamento.Entidade
{
    public static class EstenderVeiculo
    {
        public static string ApresentarInformacoes(this Veiculo veiculo)
        {
            string informacoes = "";
            informacoes += "Placa: " + veiculo.Placa + "\n";
            informacoes += "Marca: " + veiculo.Marca + "\n";
            informacoes += "Modelo: " + veiculo.Modelo + "\n";
            informacoes += "Cor: " + veiculo.Cor + "\n";
            informacoes += "Id do registro: " + veiculo.Id + "\n";
            informacoes += "Ativo: " + veiculo.Ativo + "\n";
            informacoes += "Data/hora entrada: " + veiculo.DataHoraEntrada + "\n";
            if (veiculo.DataHoraSaida != DateTime.MinValue)
                informacoes += "Data/hora saída " + veiculo.DataHoraSaida + "\n";

            return informacoes;
        }
    }
}
