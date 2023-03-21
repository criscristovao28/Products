using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Produts.api.Data;

namespace Produts.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        protected readonly IProdutosRepository _repository;

        public ProdutosController(IProdutosRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult> getProducts()
        {
            return Ok(await _repository.GetAll());
        }
    }
}
