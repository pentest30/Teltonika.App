namespace Teltonika.Core.ReverseGeoCoding.Dtos
{
    public class LocationiqResponse
    {
        public string display_name { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public Address address { get; set; }
    }
}
