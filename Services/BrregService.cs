using System.Text.Json;

namespace Gruppe20App.Services
{
    public class BrregService
    {
        private readonly HttpClient _httpClient;

        public BrregService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BrregResponse?> HentOrganisasjon(string orgnr)
        {
            var url = $"https://data.brreg.no/enhetsregisteret/api/enheter/{orgnr}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<BrregResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }

    public class BrregResponse
    {
        public string? navn { get; set; }
        public string? organisasjonsnummer { get; set; }
        public BrregOrganisasjonsform? organisasjonsform { get; set; }
    }

    public class BrregOrganisasjonsform
    {
        public string? kode { get; set; }
        public string? beskrivelse { get; set; }
    }
}
