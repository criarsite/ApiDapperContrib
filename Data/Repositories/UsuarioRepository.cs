using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using dapperAPI.Models;
using Microsoft.Data.SqlClient;

namespace dapperAPI.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

      private IDbConnection  _contexto; // adicione using System.Data;
      public UsuarioRepository()
        {
            // dotnet add package microsoft.data.sqlclient
          _contexto = new SqlConnection ("Server=localhost;Database=ApiDapper;Trusted_Connection=True;TrustServerCertificate=True;"); // using Microsoft.Data.SqlClient;
        }
        public List<Usuario> Pegar()
        {
           return _contexto.GetAll<Usuario>().ToList();
        }

        public Usuario Pegar(int id)
        {
          return _contexto.Get<Usuario>(id);
        }

        public void Criar(Usuario usuario)
        {
           usuario.Id = Convert.ToInt32(_contexto.Insert(usuario)) ;
        }

        public void Atualizar(Usuario usuario)
        {
          _contexto.Update(usuario);
        }

        public void Excluir(int id)
        {
            _contexto.Delete<Usuario>(Pegar(id));
        }

    }
}