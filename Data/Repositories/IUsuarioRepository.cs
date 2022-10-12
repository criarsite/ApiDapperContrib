using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dapperAPI.Models;

namespace dapperAPI.Data.Repositories
{
  

    public interface IUsuarioRepository
    {
        public List<Usuario>  Pegar();
        public Usuario Pegar(int id);
        public void Criar(Usuario usuario);
        public void Atualizar(Usuario usuario);
        public void Excluir(int id);
    
    }
}