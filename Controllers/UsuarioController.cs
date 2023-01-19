using ChapterAPI.Interfaces;
using ChapterAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChapterAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _IUsuarioRepository;

        public UsuarioController(IUsuarioRepository iUsuarioRepsitory)
        {
            _IUsuarioRepository = iUsuarioRepsitory;
        }

        [HttpGet]
        public IActionResult listar()
        {
            try
            {
                return Ok(_IUsuarioRepository.Listar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {

                Usuario usuarioEncontrado = _IUsuarioRepository.BuscarPorId(id);

                if (usuarioEncontrado == null)
                {
                    return NotFound("Não encontrado");
                }

                return Ok(usuarioEncontrado);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                _IUsuarioRepository.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _IUsuarioRepository.Deletar(id);
                return Ok("Usuário removido com sucesso");
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Aterar(int id, Usuario usuario)
        {
            try
            {
                _IUsuarioRepository.Atualizar(id, usuario);
                return StatusCode(204);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


    }
}