using System.Data;
using System.Text;


using meu_primeiro_projeto.Estacionamento.Entidade;
using meu_primeiro_projeto.Estacionamento.Interfaces;
using meu_primeiro_projeto.Estacionamento.Repositorio;
using meu_primeiro_projeto.Estacionamento.Servico;

namespace meu_primeiro_projeto
{
    internal class Program
    {
        static VeiculoServico _veiculoServico;
        enum OpcaoMenu
        {
            NaoInformado = 0,
            Entrada,
            Listagem,
            Ativos,
            NaoAtivos,
            BuscarPelaPlaca,
            BuscarPeloId,
            SairPelaPlaca,
            SairPeloId
        }

        static void Main(string[] args)
        {
            _veiculoServico = new VeiculoServico();

            bool executar = true;
            OpcaoMenu opcaoMenu = OpcaoMenu.NaoInformado;
            do
            {
                Console.WriteLine("Qual ação você deseja realizar?");
                Console.WriteLine("1 para registrar entrada");
                Console.WriteLine("2 para exibir a lista completa");
                Console.WriteLine("3 para listar ativos");
                Console.WriteLine("4 para listar não ativos");
                Console.WriteLine("5 para buscar pela placa");
                Console.WriteLine("6 para buscar pelo id");
                Console.WriteLine("7 para sair pela placa");
                Console.WriteLine("8 para sair pelo id");


                Console.WriteLine();
                opcaoMenu = (OpcaoMenu)Convert.ToInt32(Console.ReadLine());


                switch (opcaoMenu)
                {
                    case OpcaoMenu.Entrada:
                        {
                            MenuRegistrar();
                            break;
                        }
                    case OpcaoMenu.Listagem:
                        {
                            MenuListarTodos();

                            break;
                        }
                    case OpcaoMenu.Ativos:
                        {
                            MenuAtivos();
                            break;
                        }
                    case OpcaoMenu.NaoAtivos:
                        {
                            MenuNaoAtivos();
                            break;
                        }
                    case OpcaoMenu.BuscarPelaPlaca:
                        {
                            MenuBuscarPelaPlaca();
                            break;
                        }
                    case OpcaoMenu.BuscarPeloId:
                        {
                            MenuBuscarPelaId();
                            break;
                        }
                    case OpcaoMenu.SairPelaPlaca:
                        {
                            Console.WriteLine(value: "Informe a placa para sair");
                            string placa = Console.ReadLine();
                            MenuRegistrarSaida(placa);
                            break;
                        }
                    case OpcaoMenu.SairPeloId:
                        {
                            Console.WriteLine("Informe o id do registro");
                            string id = Console.ReadLine();
                            MenuRegistrarSaida(Guid.Parse(id));
                            break;
                        }
                    default:
                        Console.WriteLine("Opção inválida mané");
                        break;
                }

                Console.WriteLine("Deseja executar outra operação?" +
                    " sim para executar e enter para encerrar!");

                executar = Console.ReadLine().ToLower() == "sim" ? true : false;

                Console.Clear();

            } while (executar);
        }


        public static void MenuBuscarPelaPlaca()
        {
            Console.WriteLine("Informe uma placa para visualizar as informações");
            string placa = Console.ReadLine();
            Veiculo veiculo = _veiculoServico.BuscarVeiculoPelaPlaca(placa);

            Console.WriteLine(veiculo.ApresentarInformacoes());
        }

        public static void MenuBuscarPelaId()
        {
            Console.WriteLine("Informe um id para visualizar as informações");
            Guid id = Guid.Parse(Console.ReadLine());
            Veiculo veiculo = _veiculoServico.BuscarVeiculoPeloID(id);

            Console.WriteLine(veiculo.ApresentarInformacoes());
        }


        public static void MenuAtivos()
        {
            List<Veiculo> veiculos = _veiculoServico.BuscarVeiculosEstacionados();

            foreach (Veiculo veiculo in veiculos)
            {
                Console.WriteLine(veiculo);
            }

        }
        public static void MenuNaoAtivos()
        {
            List<Veiculo> veiculos = _veiculoServico.BuscarHistorico();

            foreach (Veiculo veiculo in veiculos)
            {
                Console.WriteLine(veiculo.ApresentarInformacoes());
            }

        }
        public static void MenuRegistrar()
        {
            Veiculo veiculo = new Veiculo();

            Console.WriteLine("Informe a placa");
            veiculo.Placa = Console.ReadLine();

            Console.WriteLine("Informe a marca");
            veiculo.Marca = Console.ReadLine();

            Console.WriteLine("Informe a cor");
            veiculo.Cor = Console.ReadLine();

            Console.WriteLine("Informe o modelo");
            veiculo.Modelo = Console.ReadLine();

            Guid id = _veiculoServico.RegistrarEntrada(veiculo);

            Console.WriteLine("O Id do veiculo registrado é " + id.ToString());
        }

        public static void MenuRegistrarSaida(string placa)
        {
            _veiculoServico.RegistrarSaida(placa);
        }

        public static void MenuRegistrarSaida(Guid id)
        {
            _veiculoServico.RegistrarSaida(id);

            Console.WriteLine("Veiculo foi alterado com sucesso");
        }

        public static void MenuListarTodos()
        {
            List<Veiculo> veiculos = _veiculoServico.BuscarTodos();

            foreach (Veiculo veiculo in veiculos)
            {
                Console.WriteLine(veiculo.ApresentarInformacoes());
            }
        }
    }
}
