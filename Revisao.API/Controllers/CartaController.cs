using Microsoft.AspNetCore.Mvc;
using Revisao.Application.Interfaces;
using Revisao.Application.Services;
using Revisao.Application.ViewModels;

namespace Revisao.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartaController : ControllerBase
    {
        private readonly ICartaService _cartaService;

        public CartaController(ICartaService cartaService)
        {
            _cartaService = cartaService;
        }

        [HttpPost(Name = "Adicionar")]
        public IActionResult Post(NovaCartaViewModel novoProdutoViewModel)
        {
            _cartaService.Adicionar(novoProdutoViewModel);

            return Ok();
        }

        [HttpGet(Name = "ObterTodos")]
        public IActionResult Get()
        {
            return Ok(_cartaService.ObterTodos());
        }

        [HttpGet]
        [Route("ObterPorId/{id}")]
        [ActionName("ObterPorId")]
        public IActionResult ObterPorId(Guid id)
        {
            return Ok(_cartaService.ObterPorId(id));
        }

        [HttpPut]
        [Route("Atualizar/{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CartaViewModel cartaViewModel)
        {
            await _cartaService.Atualizar(id, cartaViewModel);

            return Ok("Carta atualizada com sucesso");
        }
    }
}
