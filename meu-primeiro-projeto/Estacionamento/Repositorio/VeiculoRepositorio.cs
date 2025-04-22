using meu_primeiro_projeto.Estacionamento.Entidade;
using meu_primeiro_projeto.Estacionamento.Interfaces;

namespace meu_primeiro_projeto.Estacionamento.Repositorio
{
    public class VeiculoRepositorio : IVeiculoService
    {
        private List<Veiculo> _veiculos = [];

        public Guid RegistrarEntrada(Veiculo veiculo)
        {
            veiculo.Id = Guid.NewGuid();

            _veiculos.Add(veiculo);

            return veiculo.Id;
        }

        public Veiculo BuscarVeiculoPelaPlaca(string placa)
        {
            Veiculo veiculo = _veiculos.Find(veiculo => veiculo.Placa == placa);

            return veiculo;
        }

        public Veiculo BuscarVeiculoPeloId(Guid id)
        {
            Veiculo veiculo = _veiculos.Find(veiculo => veiculo.Id == id);

            return veiculo;
        }

        public List<Veiculo> BuscarTodos()
        {
            return _veiculos;
        }

        public List<Veiculo> BuscarVeiculosEstacionados()
        {
            List<Veiculo> veiculosEstacionados = [];

            foreach (Veiculo veiculo in _veiculos)
            {
                if (veiculo.Ativo)
                    veiculosEstacionados.Add(veiculo);
            }

            return veiculosEstacionados;
        }

        public List<Veiculo> BuscarHistorico()
        {
            List<Veiculo> veiculosEstacionados = [];

            foreach (Veiculo veiculo in _veiculos)
            {
                if (!veiculo.Ativo)
                    veiculosEstacionados.Add(veiculo);
            }

            return veiculosEstacionados;
        }

        public void Executar()
        {
            Console.WriteLine("Qual seu nome?");
        }
    }
}
