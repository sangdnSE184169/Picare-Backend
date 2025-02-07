using Helper;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Models;

namespace API.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController : ControllerBase {

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(string id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Product ID is required.");
            }
            ProductResponse? product = await ProductRepository.GetById(id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok(product.product);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("limit/{limit}")]
    public async Task<ActionResult> GetByLimit(int limit)
    {
        try
        {
            if ( limit < 0 )
            {
                return BadRequest("Amount must be a positive");
            }
            Product[]? product = await ProductRepository.GetByLimit(limit);
            if (product == null)
            {
                return NotFound($"Product with ID {limit} not found.");
            }
            return Ok(product);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("collection/{collectionId}")]
    public async Task<ActionResult> GetProductsByCollectionId(Int64 collectionId)
    {
        try
        {
            Product[]? products = await ProductRepository.GetProductWithCollectId(collectionId);
            if (products == null)
                return StatusCode(StatusCodes.Status400BadRequest);

            return StatusCode(StatusCodes.Status200OK, products);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

}

