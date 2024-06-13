using CqrsCrudDemo.Application.Products.Commands;
using CqrsCrudDemo.Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CqrsCrudDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetProducts")]
        public async Task<ActionResult> GetProducts()
        {
            Log.Information("GetProducts - start");
            var Results = await _mediator.Send(new GetProductQuery());
            Log.Information("GetProducts - Result: {@Results}",Results);
            Log.Information("GetProducts - End");

            return Ok(Results);
        }
        [HttpPost("CreateProduct")]
        public async Task<ActionResult> CreateProduct(CreateProductCommand product, CancellationToken token )
        {
            Log.Information("CreateProduct - start");
            var Results = await _mediator.Send(product,token);
            Log.Information("CreateProduct - End");
            return Ok(Results);
        }
        [HttpPost("UpdateProduct")]
        public async Task<ActionResult> UpdateProduct(UpdateProductCommand product, CancellationToken token)
        {
            Log.Information("UpdateProduct - start");
            var Results = await _mediator.Send(product, token);
            Log.Information("UpdateProduct - end");
            return Ok(Results);
        }
        [HttpDelete("DeleteProduct/{Id}")]
        public async Task<ActionResult> DeleteProduct(int Id, CancellationToken token)
        {
            Log.Information("DeleteProduct - start");
            var Results = await _mediator.Send(new DeleteProductCommand { Id=Id}, token);
            Log.Information("DeleteProduct - end");
            return Ok(Results);
        }
        [HttpGet("GetProductById/{Id}")]
        public async Task<ActionResult> GetProductById(int Id, CancellationToken token)
        {
            Log.Information("GetProductById - start");
            var Results = await _mediator.Send(new GetProductByIdQuery { Id = Id }, token);
            Log.Information("GetProductById - end");
            return Ok(Results);
        }
    }
}
