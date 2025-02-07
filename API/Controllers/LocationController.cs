using Microsoft.AspNetCore.Mvc;
using Repository;
using Models;

namespace API.Controllers;

[Route("api/location")]
[ApiController]
public class LocationController : ControllerBase {

    [HttpGet("country/{id}")]
    public async Task<ActionResult> ByCountryId(Int64 id){
        try{
            Country? temp = await LocationRepository.GetByCountryId( id );
            if( temp == null )
                return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, temp);
        } catch ( Exception ex ) {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("country/all")]
    public async Task<ActionResult> GetAll(){
        try{
            Country[]? temp = await LocationRepository.GetAllCountries();
            if( temp == null )
                return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, temp);
        } catch ( Exception ex ) {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("province/{id}")]
    public async Task<ActionResult> GetProvinces(Int64 id){
        try{
            Province[]? temp = await LocationRepository.GetWithCountryId( id );
            if( temp == null )
                return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, temp);
        } catch ( Exception ex ) {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("district/{id}")]
    public async Task<ActionResult> GetDistricts(Int64 id){
        try{
            District[]? temp = await LocationRepository.GetWithProvinceId( id );
            if( temp == null )
                return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, temp);
        } catch ( Exception ex ) {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("ward/{id}")]
    public async Task<ActionResult> GetWards(Int64 id){
        try{
            Ward[]? temp = await LocationRepository.GetWithDistrictId( id );
            if( temp == null )
                return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, temp);
        } catch ( Exception ex ) {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

}


