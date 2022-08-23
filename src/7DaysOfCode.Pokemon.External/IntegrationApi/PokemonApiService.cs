using _7DaysOfCode.Pokemon.Core;
using System.Text.Json;

namespace _7DaysOfCode.Pokemon.External.IntegrationApi
{
    public class PokemonApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly static JsonSerializerOptions jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        public PokemonApiService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        public async Task<PokeApiDTO> GetPokemons(CancellationToken cancellationToken)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "api/v2/pokemon");

            var httpClient = _httpClientFactory.CreateClient("Pokemon");
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, cancellationToken);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken);

                var jsonResult = await JsonSerializer.DeserializeAsync
                    <PokeApiDTO>(contentStream, jsonSerializerOptions, cancellationToken: cancellationToken);

                return jsonResult ?? new PokeApiDTO();
            }

            return new PokeApiDTO();
        }
    }
}
