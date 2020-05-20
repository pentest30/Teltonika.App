using System;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Teltonika.Core.ReverseGeoCoding.Dtos;

namespace Teltonika.Core.ReverseGeoCoding
{
    public class ReverseGeoCodingService
    {
        private const string KEY = "pk.cc7d7c232c3b43aa3a87127b93b22339";
        private int count = 0;
        private string[] user_agents = { "Mozilla/4.0 (Mozilla/4.0; MSIE 7.0; Windows NT 5.1; FDM; SV1)"
            , "Mozilla/4.0 (Mozilla/4.0; MSIE 7.0; Windows NT 5.1; FDM; SV1; .NET CLR 3.0.04506.30)",
            "Mozilla/4.0 (Windows; MSIE 7.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)",
            "Mozilla/4.0 (Windows; U; Windows NT 5.0; en-US) AppleWebKit/532.0 (KHTML, like Gecko) Chrome/3.0.195.33 Safari/532.0",
            "Mozilla/4.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/525.19 (KHTML, like Gecko) Chrome/1.0.154.59 Safari/525.19",
            "Mozilla/4.0 (compatible; MSIE 6.0; Linux i686 ; en) Opera 9.70",
            "Mozilla/4.0 (compatible; MSIE 6.0; Mac_PowerPC; en) Opera 9.24",
            "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; de) Opera 9.50",
            "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; en) Opera 9.24",
            "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; en) Opera 9.26",
            "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; es-la) Opera 9.27",
            "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; YPC 3.2.0; SLCC1; .NET CLR 2.0.50727; .NET CLR 3.0.04506)"
        };
     
        public async Task<string> ReverseGeoCodingAsync(double Lat, double Long)
        {
             var lat = Lat.ToString(CultureInfo.InvariantCulture).Replace(",", ".");
            var lon = Long.ToString(CultureInfo.InvariantCulture).Replace(",", ".");
            var client = new HttpClient();
            var url = $"https://us1.locationiq.com/v1/reverse.php?key={KEY}&lat={lat}&lon={lon}&format=json";
            var rd = new Random();
     
            HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var r = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var ressult= JsonConvert.DeserializeObject<LocationiqResponse>(r);
                return ressult.display_name;
            }

            return null;

        }
        public  async Task<NominatimResult> ExecuteQueryAsync(double lat, double lng)
        {
            var client = new RestClient();
            var latitude =lat. ToString(CultureInfo.InvariantCulture).Replace(",", ".");
            var longitude = lng.ToString(CultureInfo.InvariantCulture).Replace(",", ".");
           
            var url = $"https://nominatim.openstreetmap.org/reverse.php?format=json&lat={latitude}&lon={longitude}";
            var request = new RestRequest(Method.GET);
            //request.Resource = "wsRest/wsServerArticle/getArticle";
            client.BaseUrl = new Uri(url);
            var rd = new Random();
            client.UserAgent = user_agents[rd.Next(0, user_agents.Length)]; 
            try
            {
                
                var response = await client.ExecutePostTaskAsync<NominatimResult>(request).ConfigureAwait(false);
                if (response.ErrorException != null)
                {
                    const string message = "Error retrieving response.  Check inner details for more info.";
                    throw new ApplicationException(message, response.ErrorException);
                   
                }

                return response.Data;
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return new NominatimResult();
                // throw;
            }

        }
        public  async Task<string> ReverseGoecodeAsync(double lat, double log)
        {
            try
            {
                var r = await ExecuteQueryAsync(lat, log).ConfigureAwait(false);
                Thread.Sleep(1000);
                if (r.display_name != null)
                    return r.display_name;
            }
            catch (Exception e)
            {
               // Console.WriteLine(e);
                Thread.Sleep(1000);
                var ad = await ReverseGeoCodingAsync(lat, log)
                    .ConfigureAwait(false);
                if (ad == null) return string.Empty;
                Thread.Sleep(1000);
                return ad;
                //throw;
            }

            return string.Empty;
        }

    }
}
