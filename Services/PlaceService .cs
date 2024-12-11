namespace NearestTeachers.Services
{
    //public class PlaceService
    //{
    //}


    using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NearestTeachers.Models; // Make sure to adjust the namespace according to your project structure

public interface IPlaceService
    {
        Task<List<Place>> GetNearbyPlacesAsync(double lat, double lng, double radius);
    }

    public class PlaceService : IPlaceService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _googleMapsApiKey;

        public PlaceService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _googleMapsApiKey = configuration["GoogleMapsApiKey"];
        }
        public async Task<List<Place>> GetNearbyPlacesAsync(double lat, double lng, double radius)
        {
            var url = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={lat},{lng}&radius={radius}&key={_googleMapsApiKey}";

            using (var client = _httpClientFactory.CreateClient())
            {
                var response = await client.GetStringAsync(url);
                var placesResponse = JsonConvert.DeserializeObject<PlacesResponse>(response);

                return placesResponse.Results;
            }
        }

        //public async Task<List<Place>> GetNearbyPlacesAsync(double lat, double lng, double radius)
        //{
        //    var url = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={lat},{lng}&radius={radius}&key={_googleMapsApiKey}";

        //    using (var client = _httpClientFactory.CreateClient())
        //    {
        //        var response = await client.GetStringAsync(url);
        //        var placesResponse = JsonConvert.DeserializeObject<PlacesResponse>(response);

        //        return placesResponse.Results;
        //    }
        //}
    }

}
