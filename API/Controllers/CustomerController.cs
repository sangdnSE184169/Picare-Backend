using Helper;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

namespace API.Controllers;

[Route("api/customer")]
[ApiController]
public class CustomerController : ControllerBase {

    [HttpGet("query/{info}")]
    public async Task<ActionResult> GetByInfo( string info ){
        try{
            Customer[]? temp = await CustomerReposiroty.GetByQuery( info );
            if( temp == null )
                return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, temp);
        } catch ( Exception ex ) {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost("createwithaddress")]
    public async Task<ActionResult> CreateWithAddress( CustomerWithAddressRequest info ){
        try{
            string temp = await CustomerReposiroty.CreateCustomerWithAddress( info );
            if( temp.Contains("Error") )
                return StatusCode(StatusCodes.Status400BadRequest, temp);
            if( temp.Contains("Failed") )
                return StatusCode(StatusCodes.Status500InternalServerError, temp);
            return StatusCode(StatusCodes.Status201Created, temp);
        } catch ( Exception ex ) {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost("create")]
    public async Task<ActionResult> CreateWithoutAddress( CustomerInfoOnlyRequest info ){
        try{
            string temp = await CustomerReposiroty.CreateCustomerOnly( info );
            if( temp.Contains("Error") )
                return StatusCode(StatusCodes.Status400BadRequest, temp);
            if( temp.Contains("Failed") )
                return StatusCode(StatusCodes.Status500InternalServerError, temp);
            return StatusCode(StatusCodes.Status201Created, temp);
        } catch ( Exception ex ) {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult> CreateWithoutAddress( Int64 id, string json ){
        try{
            string temp = await CustomerReposiroty.UpdateCustomer( id, json );
            if( temp.Contains("Error") )
                return StatusCode(StatusCodes.Status400BadRequest, temp);
            if( temp.Contains("Failed") )
                return StatusCode(StatusCodes.Status500InternalServerError, temp);
            return StatusCode(StatusCodes.Status200OK, temp);
        } catch ( Exception ex ) {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    


}


