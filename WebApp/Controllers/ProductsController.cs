using System.Threading.Tasks;
using Application.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async  Task<IActionResult> GetProductsAsync()
        {
            return Ok(await _mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            return Ok(await _mediator.Send(new Details.Query{Id = id}));
        }
    }
}