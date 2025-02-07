using Microsoft.AspNetCore.Mvc;
using Model.Model;
using System;
using System.Net.Http;
using System.Threading.Tasks;

[Route("api/zalo")]
[ApiController]
public class ZaloController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public ZaloController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpPost("get-phone")]
    public async Task<IActionResult> GetZaloPhone([FromBody] ZaloRequest request)
    {
        if (string.IsNullOrEmpty(request.AccessToken) || string.IsNullOrEmpty(request.Code))
        {
            return BadRequest(new { message = "Access token hoặc Code không được để trống!" });
        }

        string endpoint = "https://graph.zalo.me/v2.0/me/info";

        var httpRequest = new HttpRequestMessage(HttpMethod.Get, endpoint);
        httpRequest.Headers.Add("access_token", request.AccessToken);
        httpRequest.Headers.Add("code", request.Code);
        httpRequest.Headers.Add("secret_key", "W3bVLpFmkIcsGVuCWhY5"); 

        try
        {
            HttpResponseMessage response = await _httpClient.SendAsync(httpRequest);
            string responseBody = await response.Content.ReadAsStringAsync();

            return Ok(new { phone_number = responseBody });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Lỗi khi gọi API Zalo", error = ex.Message });
        }
    }
}
