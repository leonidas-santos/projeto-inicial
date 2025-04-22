using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using meu_primeiro_projeto.Estacionamento.Entidade;

namespace meu_primeiro_projeto.Estacionamento.Interfaces
{
    public interface IVeiculoService
    {
        Guid RegistrarEntrada(Veiculo veiculo);
        Veiculo BuscarVeiculoPelaPlaca(string placa);
        List<Veiculo> BuscarTodos();
        List<Veiculo> BuscarVeiculosEstacionados();
        List<Veiculo> BuscarHistorico();
    }
}
