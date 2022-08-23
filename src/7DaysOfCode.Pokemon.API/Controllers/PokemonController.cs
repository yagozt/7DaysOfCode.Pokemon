using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace _7DaysOfCode.Pokemon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPokemons(CancellationToken cancellationToken)
        {
            using var client = new HttpClient();
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://pokeapi.co/api/v2/pokemon");
            var responseResult = await client.SendAsync(requestMessage, cancellationToken);
            using var contentStream = await responseResult.Content.ReadAsStreamAsync(cancellationToken);
            var contentJsonResult = await JsonSerializer.DeserializeAsync<PokeApiDTO>(contentStream, new JsonSerializerOptions {  PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true },cancellationToken: cancellationToken);

            return Ok(contentJsonResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPokemon([FromRoute]int id, CancellationToken cancellationToken)
        {
            using var client = new HttpClient();
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://pokeapi.co/api/v2/pokemon/{id}");
            var responseResult = await client.SendAsync(requestMessage, cancellationToken);
            var contentString = await responseResult.Content.ReadAsStringAsync(cancellationToken);

            return Ok(contentString);
        }
    }
}
