using _7DaysOfCode.Pokemon.External.IntegrationApi;
using Microsoft.AspNetCore.Mvc;

namespace _7DaysOfCode.Pokemon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonApiService _pokemonApiService;

        public PokemonController(PokemonApiService pokemonApiService)
        {
            _pokemonApiService = pokemonApiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPokemons(CancellationToken cancellationToken)
        {
            var pokemons = await _pokemonApiService.GetPokemons(cancellationToken);

            return Ok(pokemons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPokemon([FromRoute] int id, CancellationToken cancellationToken)
        {
            var pokemons = await _pokemonApiService.GetPokemon(id, cancellationToken);

            return Ok(pokemons);
        }
    }
}
