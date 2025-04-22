using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using meu_segundo_projeto.Entidade;
using meu_segundo_projeto.Repositorio;

namespace meu_segundo_projeto.Servico
{
    public class PessoaServico
    {
        PessoaRepositorio _pessoaRepositorio; 

        public PessoaServico(string caminhoBanco)
        {
            _pessoaRepositorio = new PessoaRepositorio(caminhoBanco);
        }

        public void Adicionar(Pessoa pessoa) => _pessoaRepositorio.Adicionar(pessoa);

        public void Remover(Pessoa pessoa) => _pessoaRepositorio.Remover(pessoa);

        public Pessoa BuscarPeloCPF(string cpf) => _pessoaRepositorio.BuscarPeloCPF(cpf);

        public void Atualizar(Pessoa pessoa) => _pessoaRepositorio.Atualizar(pessoa);

        public List<Pessoa> BuscarTodos() => _pessoaRepositorio.BuscarTodos();
    }
}