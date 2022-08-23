namespace _7DaysOfCode.Pokemon.API.Controllers
{
    public class PokeApiDTO
    {
        public PokeApiDTO()
        {
            Results = Array.Empty<PokemonDTO>();
        }

        public int Count { get; set; }
        public string Next { get; set; } = string.Empty;
        public string Previous { get; set; } = string.Empty;
        public PokemonDTO[] Results { get; set; }

        public class PokemonDTO
        {
            public string Name { get; set; } = string.Empty;
            public string Url { get; set; } = string.Empty;
        }
    }
}