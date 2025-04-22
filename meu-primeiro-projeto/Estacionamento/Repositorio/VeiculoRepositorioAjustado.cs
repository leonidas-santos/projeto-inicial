//using System.Collections.Generic;
//using System.Numerics;
//using meu_primeiro_projeto.Estacionamento.Entidade;
//using Microsoft.Data.SqlClient;

//namespace meu_primeiro_projeto.Estacionamento.Repositorio
//{
//    public class VeiculoRepositorioAjustado
//    {
//        public Guid RegistrarEntrada(Veiculo veiculo)
//        {
//            veiculo.Id = Guid.CreateVersion7();

//            using (SqlConnection sqlConnection = new SqlConnection())
//            {
//                string comandoSQL = "INSERT INTO Veiculo (Id, Cor, Placa, Modelo, Marca, Ativo, DataHoraEntrada, DataHoraSaida) " +
//                    "VALUES (@Id, @Cor, @Placa, @Modelo, @Marca, @Ativo, @DataHoraEntrada, @DataHoraSaida)";
//                using (SqlCommand sqlCommand = new SqlCommand(comandoSQL, sqlConnection))
//                {
//                    sqlCommand.Parameters.AddWithValue("@Id", veiculo.Id);
//                    sqlCommand.Parameters.AddWithValue("@Cor", veiculo.Cor);
//                    sqlCommand.Parameters.AddWithValue("@Placa", veiculo.Placa);
//                    sqlCommand.Parameters.AddWithValue("@Modelo", veiculo.Modelo);
//                    sqlCommand.Parameters.AddWithValue("@Marca", veiculo.Marca);
//                    sqlCommand.Parameters.AddWithValue("@Ativo", veiculo.Ativo);
//                    sqlCommand.Parameters.AddWithValue("@DataHoraEntrada", veiculo.DataHoraEntrada);
//                    sqlCommand.Parameters.AddWithValue("@DataHoraSaida", veiculo.DataHoraSaida);
//                    sqlConnection.Open();
//                    sqlCommand.ExecuteNonQuery();
//                }
//            }
//            return veiculo.Id;
//        }

//        public bool RegistrarSaida(Guid idVeiculo)
//        {
//            Veiculo veiculoRegistrado = ObterVeiculo(idVeiculo);
//            if (veiculoRegistrado != null)
//            {
//                veiculoRegistrado.DataHoraSaida = DateTime.Now;
//                veiculoRegistrado.Ativo = false;

//                using (SqlConnection sqlConnection = new SqlConnection())
//                {
//                    string comandoSQL = "UPDATE VEICULOS SET ATIVO = @ATIVO, DATAHORASAIDA = @DATAHORASAIDA WHERE ID = @ID";
//                    using (SqlCommand sqlCommand = new SqlCommand(comandoSQL, sqlConnection))
//                    {
//                        sqlCommand.Parameters.AddWithValue("@ATIVO", veiculoRegistrado.Ativo);
//                        sqlCommand.Parameters.AddWithValue("@DATAHORASAIDA", veiculoRegistrado.DataHoraSaida);
//                        sqlCommand.Parameters.AddWithValue("@ID", veiculoRegistrado.Id);
//                        sqlConnection.Open();
//                        sqlCommand.ExecuteNonQuery();
//                    }
//                    return true;
//                }
//            }
//            return false;
//        }

//        public bool RegistrarSaida(string placa)
//        {
//            Veiculo veiculoRegistrado = ObterVeiculo(placa);
//            if (veiculoRegistrado != null)
//            {
//                veiculoRegistrado.DataHoraSaida = DateTime.Now;
//                veiculoRegistrado.Ativo = false;

//                using (SqlConnection sqlConnection = new SqlConnection())
//                {
//                    string comandoSQL = "UPDATE VEICULOS SET ATIVO = @ATIVO, DATAHORASAIDA = @DATAHORASAIDA WHERE PLACA = @PLACA";
//                    using (SqlCommand sqlCommand = new SqlCommand(comandoSQL, sqlConnection))
//                    {
//                        sqlCommand.Parameters.AddWithValue("@ATIVO", veiculoRegistrado.Ativo);
//                        sqlCommand.Parameters.AddWithValue("@DATAHORASAIDA", veiculoRegistrado.DataHoraSaida);
//                        sqlCommand.Parameters.AddWithValue("@PLACA", veiculoRegistrado.Placa);
//                        sqlConnection.Open();
//                        sqlCommand.ExecuteNonQuery();
//                    }
//                    return true;
//                }
//            }
//            return false;
//        }

//        public List<Veiculo> ObterVeiculosEstacionados()
//        {
//            List<Veiculo> veiculos = new List<Veiculo>();

//            using (SqlConnection sqlConnection = new SqlConnection())
//            {
//                string comandoSQL = "SELECT * FROM VEICULOS WHERE ATIVO = TRUE";
//                using (SqlCommand sqlCommand = new SqlCommand(comandoSQL, sqlConnection))
//                {
//                    sqlConnection.Open();
//                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

//                    if (sqlDataReader.Read())
//                    {
//                        Veiculo veiculo = new Veiculo()
//                        {
//                            Ativo = (bool)sqlDataReader["Ativo"],
//                            Cor = sqlDataReader["Cor"].ToString(),
//                            DataHoraEntrada = (DateTime)sqlDataReader["DataHoraEntrada"],
//                            DataHoraSaida = (DateTime)sqlDataReader["DataHoraSaida"],
//                            Id = (Guid)sqlDataReader["Id"],
//                            Marca = sqlDataReader["Marca"].ToString(),
//                            Modelo = sqlDataReader["Modelo"].ToString(),
//                            Placa = sqlDataReader["Placa"].ToString()
//                        };
//                        veiculos.Add(veiculo);
//                    }
//                    return veiculos;
//                }
//            }
//        }

//        public List<Veiculo> ObterHistoricoVeiculos()
//        {
//            List<Veiculo> veiculos = new List<Veiculo>();

//            using (SqlConnection sqlConnection = new SqlConnection())
//            {
//                string comandoSQL = "SELECT * FROM VEICULOS WHERE ATIVO = FALSE";
//                using (SqlCommand sqlCommand = new SqlCommand(comandoSQL, sqlConnection))
//                {
//                    sqlConnection.Open();
//                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

//                    if (sqlDataReader.Read())
//                    {
//                        Veiculo veiculo = new Veiculo()
//                        {
//                            Ativo = (bool)sqlDataReader["Ativo"],
//                            Cor = sqlDataReader["Cor"].ToString(),
//                            DataHoraEntrada = (DateTime)sqlDataReader["DataHoraEntrada"],
//                            DataHoraSaida = (DateTime)sqlDataReader["DataHoraSaida"],
//                            Id = (Guid)sqlDataReader["Id"],
//                            Marca = sqlDataReader["Marca"].ToString(),
//                            Modelo = sqlDataReader["Modelo"].ToString(),
//                            Placa = sqlDataReader["Placa"].ToString()
//                        };
//                        veiculos.Add(veiculo);
//                    }
//                    return veiculos;
//                }
//            }
//        }

//        public List<Veiculo> ObterTodosVeiculos()
//        {
//            List<Veiculo> veiculos = new List<Veiculo>();

//            using (SqlConnection sqlConnection = new SqlConnection())
//            {
//                string comandoSQL = "SELECT * FROM VEICULOS";
//                using (SqlCommand sqlCommand = new SqlCommand(comandoSQL, sqlConnection))
//                {
//                    sqlConnection.Open();
//                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

//                    if (sqlDataReader.Read())
//                    {
//                        Veiculo veiculo = new Veiculo()
//                        {
//                            Ativo = (bool)sqlDataReader["Ativo"],
//                            Cor = sqlDataReader["Cor"].ToString(),
//                            DataHoraEntrada = (DateTime)sqlDataReader["DataHoraEntrada"],
//                            DataHoraSaida = (DateTime)sqlDataReader["DataHoraSaida"],
//                            Id = (Guid)sqlDataReader["Id"],
//                            Marca = sqlDataReader["Marca"].ToString(),
//                            Modelo = sqlDataReader["Modelo"].ToString(),
//                            Placa = sqlDataReader["Placa"].ToString()
//                        };
//                        veiculos.Add(veiculo);  
//                    }
//                    return veiculos;
//                }
//            }
//        }

//        public Veiculo ObterVeiculo(Guid id)
//        {
//            using (SqlConnection sqlConnection = new SqlConnection())
//            {
//                string comandoSQL = "SELECT * FROM VEICULOS WHERE ID = @ID";
//                using (SqlCommand sqlCommand = new SqlCommand(comandoSQL, sqlConnection))
//                {
//                    sqlCommand.Parameters.AddWithValue("@Id", id);
//                    sqlConnection.Open();
//                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

//                    if (sqlDataReader.Read())
//                    {
//                        return new Veiculo()
//                        {
//                            Ativo = (bool)sqlDataReader["Ativo"],
//                            Cor = sqlDataReader["Cor"].ToString(),
//                            DataHoraEntrada = (DateTime)sqlDataReader["DataHoraEntrada"],
//                            DataHoraSaida = (DateTime)sqlDataReader["DataHoraSaida"],
//                            Id = (Guid)sqlDataReader["Id"],
//                            Marca = sqlDataReader["Marca"].ToString(),
//                            Modelo = sqlDataReader["Modelo"].ToString(),
//                            Placa = sqlDataReader["Placa"].ToString()
//                        };
//                    }
//                    return null;
//                }
//            }
//        }

//        public Veiculo ObterVeiculo(string placa)
//        {
//            using (SqlConnection sqlConnection = new SqlConnection())
//            {
//                string comandoSQL = "SELECT * FROM VEICULOS WHERE PLACA = @PLACA";
//                using (SqlCommand sqlCommand = new SqlCommand(comandoSQL, sqlConnection))
//                {
//                    sqlCommand.Parameters.AddWithValue("@PLACA", placa);
//                    sqlConnection.Open();
//                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

//                    if (sqlDataReader.Read())
//                    {
//                        return new Veiculo()
//                        {
//                            Ativo = (bool)sqlDataReader["Ativo"],
//                            Cor = sqlDataReader["Cor"].ToString(),
//                            DataHoraEntrada = (DateTime)sqlDataReader["DataHoraEntrada"],
//                            DataHoraSaida = (DateTime)sqlDataReader["DataHoraSaida"],
//                            Id = (Guid)sqlDataReader["Id"],
//                            Marca = sqlDataReader["Marca"].ToString(),
//                            Modelo = sqlDataReader["Modelo"].ToString(),
//                            Placa = sqlDataReader["Placa"].ToString()
//                        };
//                    }
//                    return null;
//                }
//            }
//        }
//    }
//}
