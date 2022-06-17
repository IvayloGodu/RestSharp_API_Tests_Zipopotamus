using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Zipopotamus.APITests
{
    internal class Location
    {
        [JsonPropertyName("post code")]
        public string postCode { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
        
        [JsonPropertyName("country abreviation")]
        public string CountryAbbreviation { get; set; }
        
        [JsonPropertyName("places")]
        public List<Place> Places { get; set; }
    }
}