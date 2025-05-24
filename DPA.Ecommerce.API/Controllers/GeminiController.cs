using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DPA.Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GeminiController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public GeminiController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public class GeminiAskRequest
        {
            public string Question { get; set; }
        }

        [HttpPost("ask")]
        public async Task<IActionResult> AskGemini([FromBody] GeminiAskRequest request)
        {
            var apiKey = _configuration["Gemini:ApiKey"];
            var endpoint = _configuration["Gemini:Endpoint"];
            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(endpoint))
                return BadRequest("Gemini ApiKey or Endpoint not configured.");

            var httpClient = _httpClientFactory.CreateClient();
            var payload = new
            {
                contents = new[]
                {
                    new { parts = new[] { new { text = request.Question } } }
                }
            };
            var jsonPayload = JsonSerializer.Serialize(payload);
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{endpoint}?key={apiKey}")
            {
                Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json")
            };

            var response = await httpClient.SendAsync(httpRequest);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, responseContent);

            return Ok(JsonDocument.Parse(responseContent));
        }
    }
}
