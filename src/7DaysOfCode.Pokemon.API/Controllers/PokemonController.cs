using _7DaysOfCode.Pokemon.Core;
using _7DaysOfCode.Pokemon.External.IntegrationApi;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace _7DaysOfCode.Pokemon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPokemons([FromServices] PokemonApiService pokemonApiService, CancellationToken cancellationToken)
        {
            var pokemons = await pokemonApiService.GetPokemons(cancellationToken);

            return Ok(pokemons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPokemon([FromRoute] int id, CancellationToken cancellationToken)
        {
            using var client = new HttpClient();
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://pokeapi.co/api/v2/pokemon/{id}");
            var responseResult = await client.SendAsync(requestMessage, cancellationToken);
            var contentString = await responseResult.Content.ReadAsStringAsync(cancellationToken);

            return Ok(contentString);
        }
    }
}
