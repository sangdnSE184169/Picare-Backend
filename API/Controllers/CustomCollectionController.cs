using Microsoft.AspNetCore.Mvc;
using Repository;
using Models;

namespace API.Controllers;

[Route("api/custom_collection")]
[ApiController]
public class CustomCollectionController : ControllerBase {

    [HttpGet]
    public async Task<ActionResult> Get(){
        try{
            string query = this.Request.QueryString.ToString();
            CustomCollection[]? temp = await CustomCollectionRepository.GetWithQuery( query );
            if( temp == null )
                return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, temp);
        } catch ( Exception ex ) {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(Int64 id){
        try{
            CustomCollection? temp = await CustomCollectionRepository.GetWithId( id );
            if( temp == null )
                return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, temp);
        } catch ( Exception ex ) {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}

