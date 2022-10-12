using dapperAPI.Data.Repositories;
using dapperAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace dapperAPI.Controllers
{
    [Route("api/Contrib/Usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _repositoty;

       public UsuariosController()
       {
        _repositoty = new UsuarioRepository();
       }

       /* Crud 
          GET  = Pegar  -> Obter a lista de usuarios
          GET  = Pegar  -> Obter o usuario passando o ID
          POST = Criar  -> Cadastrar um usuario
          PUT  = Atualizar -> Atualizar um usuario
          Delete = Excluir -> Remover um usuario
       */
        
        [HttpGet]
        public IActionResult Pegar()
        {
            return Ok(_repositoty.Pegar());
        }

        [HttpGet("{id}")]
        public IActionResult Pegar(int id)
        {
            var usuario = _repositoty.Pegar(id);
            if (usuario == null) return NotFound();

             return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Usuario usuario)
        {
           _repositoty.Criar(usuario);
           return Ok(usuario);
        }
        

       [HttpPut]
       public IActionResult Atualizar([FromBody]Usuario usuario)
       {
         _repositoty.Atualizar(usuario);
         return Ok(usuario);
       }

       [HttpDelete("{id}")]
       public IActionResult Excluir(int id)
       {
         _repositoty.Excluir(id);
         return Ok();
 
       }

    }
}