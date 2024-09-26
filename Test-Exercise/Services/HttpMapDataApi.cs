namespace Test_Exercise.Services
{
    public class HttpMapDataApi
    {
        private HttpClient _httpClient;

        public HttpMapDataApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GasStationDto>> GetMapDataAsync(string searchData)
        {
            int limit = 50; 
            int offset = 0; 
            List<GasStationDto> gasStations = new List<GasStationDto>();
            while (offset < 300) // for avoid blocking by API, may be more
            {
                var response = await _httpClient.GetAsync($"?q={searchData}&format=json&addressdetails=1&limit={limit}&offset={offset}");
                var dtos = await response.Content.ReadFromJsonAsync<GasStationDto[]>();
                if (dtos == null || dtos.Length == 0) break;
                gasStations.AddRange(dtos);
                offset += limit;

            }

            return gasStations; 
        }

    }
}
