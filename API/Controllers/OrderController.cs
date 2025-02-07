using Microsoft.AspNetCore.Mvc;
using Repository;
using Helper;
using Models;

namespace API.Controllers;

[Route("api/order")]
[ApiController]
public class OrderController : ControllerBase {

    [HttpPost("create")]
    public async Task<ActionResult> GetById(OrderRequest id){
        try{
            string temp = await OrderRepository.PlaceOrder( id );
            if( temp == null )
                return StatusCode(StatusCodes.Status500InternalServerError);
            if( temp.Equals("OK") )
                return StatusCode(StatusCodes.Status201Created, temp);
            return StatusCode(StatusCodes.Status400BadRequest, temp);
        } catch ( Exception ex ) {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("query/{query}")]
    public async Task<ActionResult> GetByPhoneNumber(string query){
        try{
            PlacedOrder[]? temp = await OrderRepository.GetByCustomerInfo( query );
            if( temp == null )
                return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, temp);
        } catch ( Exception ex ) {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

}


