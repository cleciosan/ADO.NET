using eCommerce.API.Models;
using eCommerce.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosProcedureController : ControllerBase
    {
        private IUsuarioRepository _repository;

        public UsuariosProcedureController()
        {
            _repository = new UsuarioProcedureRepository();
        }

        //=> Criar métodos para permitir fazer o CRUD

        // => GET -> Obter a lista de usuários;
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_repository.Get());
        }

        //=> GET -> Obter o usuário passando o ID;
        [HttpGet("{id}")]
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
        public IActionResult Insert([FromBody] Usuario usuario)
        {
            try
            {
                _repository.Insert(usuario);
                return Ok(usuario);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        //=> PUT -> Atualizar um usuário;
        [HttpPut]
        public IActionResult Update([FromBody] Usuario usuario)
        {
            try
            {
                _repository.Update(usuario);
                return Ok(usuario);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        // => DELETE -> Remover usuários;
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }

    }
}
