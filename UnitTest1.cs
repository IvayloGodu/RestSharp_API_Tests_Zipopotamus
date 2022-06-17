using NUnit.Framework;
using RestSharp;
using RestSharp.Serializers.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace Zipopotamus.APITests
{
    public class ZipopotamusApiTests
    {
        private const string url = "https://api.zippopotam.us";
        private RestClient client;
        private RestRequest request;

        [SetUp]
        public void Setup()
        {
            this.client = new RestClient(url);
        }

        [TestCase("BG", "1000", "Sofija")]
        [TestCase("BG", "8600", "Jambol")]
        [TestCase("BG", "8600", "Jambol")]
        [TestCase("CA", "M5S", "Toronto")]
        [TestCase("GB", "B1", "Birmingham")]
        [TestCase("DE", "01067", "Dresden")]
        public void TestZipopotamus(string country_code, string Zip_code, string expected_town)
        {
            var request = new RestRequest(country_code + "/" + Zip_code);
            
            var response = client.Execute(request, Method.Get);
            var location = new SystemTextJsonSerializer().Deserialize<Location>(response);


            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));     
            Assert.That(Zip_code, Is.EqualTo(location.postCode));
            StringAssert.Contains(expected_town, location.Places[0].PlaceName);

            
        }
    }
}