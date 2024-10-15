using BiddHub.DTO;
using BiddHub.Models;
using BiddHub.Models.Listings;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // POST: api/products
    //[HttpPost]
    //public async Task<IActionResult> Products([FromBody] ProductsDTO product)
    //public async Task<ActionResult<ProductsDTO>> AddProduct([FromBody] Products product)
    //{
        //_context.Products.Add(product);
        //await _context.SaveChangesAsync();

        //return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    //}

    // GET: api/products/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Products>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return product;
    }
}
