using eCommerce.API.Models;
using eCommerce.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _repository;

        public UsuariosController()
        {
            _repository = new UsuarioRepository();
        }

        /*
        => Criar métodos para permitir fazer o CRUD
        
        => DELETE -> Remover um usuário
        */

        // => GET -> Obter a lista de usuários;
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_repository.Get());
        }

        //=> GET -> Obter o usuário passando o ID;
        [HttpGet("{Id}")]
        public IActionResult ObterUsuario(int id)
        {
            var usuario = _repository.Get(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        //=> POST -> Cadastrar um usuário;
        [HttpPost]
        public IActionResult Insert([FromBody]Usuario usuario)
        {
            _repository.Insert(usuario);
            return Ok(usuario);
        }

        //=> PUT -> Atualizar um usuário;
        [HttpPut]
        public IActionResult Update([FromBody]Usuario usuario)
        {
            _repository.Update(usuario);
            return Ok(usuario);
        }
    }
}
