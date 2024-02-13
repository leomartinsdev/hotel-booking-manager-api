using System.Net.Http;
using System.Net.Sockets;
using Microsoft.Data.SqlClient;
using HotelManagerAPI.Dto;
using HotelManagerAPI.Repository;

namespace HotelManagerAPI.Services
{
    public class GeoService : IGeoService
    {
        private readonly HttpClient _client;
        public GeoService(HttpClient client)
        {
            _client = client;
        }

        public async Task<object> GetGeoStatus()
        {
            var response = await _client.GetAsync("https://nominatim.openstreetmap.org/status.php?format=json");

            response.Headers.Add("Accept", "application/json");
            response.Headers.Add("User-Agent", "aspnet-user-agent");

            if (!response.IsSuccessStatusCode)
            {
                return default(Object);
            }

            var result = await response.Content.ReadFromJsonAsync<object>();

            return result;
        }

        public async Task<GeoDtoResponse> GetGeoLocation(GeoDto geoDto)
        {
            var response = await _client.GetAsync($"https://nominatim.openstreetmap.org/search?street={geoDto.Address}&city={geoDto.City}&country=Brazil&state={geoDto.State}&format=json&limit=1");
            response.Headers.Add("Accept", "application/json");
            response.Headers.Add("User-Agent", "aspnet-user-agent");

            if (!response.IsSuccessStatusCode)
            {
                return default(GeoDtoResponse);
            }

            var result = await response.Content.ReadFromJsonAsync<List<GeoDtoResponse>>();

            return new GeoDtoResponse
            {
                lat = result[0].lat,
                lon = result[0].lon
            };
        }

        public async Task<List<GeoDtoHotelResponse>> GetHotelsByGeo(GeoDto geoDto, IHotelRepository repository)
        {
            var hotels = repository.GetHotels();
            var distances = new List<GeoDtoHotelResponse>();

            var inputAddress = await GetGeoLocation(geoDto);

            foreach (var hotel in hotels)
            {
                var hotelLocation = await GetGeoLocation(new GeoDto() { Address = hotel.address, City = hotel.cityName, State = hotel.state });
                var distance = CalculateDistance(inputAddress.lat, inputAddress.lon, hotelLocation.lat, hotelLocation.lon);

                distances.Add(new GeoDtoHotelResponse()
                {
                    HotelId = hotel.hotelId,
                    Name = hotel.name,
                    CityName = hotel.cityName,
                    State = hotel.state,
                    Distance = distance
                });
            }

            return distances;
        }

        public int CalculateDistance(string latitudeOrigin, string longitudeOrigin, string latitudeDestiny, string longitudeDestiny)
        {
            double latOrigin = double.Parse(latitudeOrigin.Replace('.', ','));
            double lonOrigin = double.Parse(longitudeOrigin.Replace('.', ','));
            double latDestiny = double.Parse(latitudeDestiny.Replace('.', ','));
            double lonDestiny = double.Parse(longitudeDestiny.Replace('.', ','));
            double R = 6371;
            double dLat = radiano(latDestiny - latOrigin);
            double dLon = radiano(lonDestiny - lonOrigin);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(radiano(latOrigin)) * Math.Cos(radiano(latDestiny)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = R * c;
            return int.Parse(Math.Round(distance, 0).ToString());
        }

        public double radiano(double degree)
        {
            return degree * Math.PI / 180;
        }

    }
}