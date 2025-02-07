using Microsoft.AspNetCore.Mvc;
using Repository;
using Models;

namespace API.Controllers;

[Route("api/discount")]
[ApiController]
public class DiscountController : ControllerBase {

    [HttpGet]
    public async Task<ActionResult> GetAll(){
        try{
            Discount[]? temp = await DiscountRepository.GetAll();
            if( temp == null )
                return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, temp);
        } catch ( Exception ex ) {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById( Int64 id ){
        try{
            Discount? temp = await DiscountRepository.GetById( id );
            if( temp == null )
                return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, temp);
        } catch ( Exception ex ) {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("code/{code}")]
    public async Task<ActionResult> GetByCode( string code ){
        try{
            Discount[]? temp = await DiscountRepository.GetByCode( code );
            if( temp == null )
                return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, temp);
        } catch ( Exception ex ) {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

}


