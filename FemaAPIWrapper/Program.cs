using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
using System.Net;

namespace FemaAPIWrapper
{
    class Program
    {
        static HttpClient httpClient = new HttpClient();
        
        static void Main(string[] args)
        {

            var femaInfo = GetFemaInfo();

            var json = JsonConvert.DeserializeObject<DisasterDeclarationsSummaries.FemaInfo>(femaInfo.Result);

            json.DisasterDeclarationsSummaries.OrderByDescending(j => j.DisasterNumber);

            foreach (var j in json.DisasterDeclarationsSummaries)
            {
                if (!j.PlaceCode.HasValue)
                {
                    j.PlaceCode = -1;
                }
                Console.WriteLine($"{j.DisasterNumber}, {j.Title}, {j.State}, {j.PlaceCode}");
            }

            GetJSONFile();
        }

        public static async Task<string> GetFemaInfo()
        {
            HttpResponseMessage resp = httpClient.GetAsync("https://www.fema.gov/api/open/v1/DisasterDeclarationsSummaries").Result;
            resp.EnsureSuccessStatusCode();

            var jsonString = await resp.Content.ReadAsStringAsync();



            return jsonString;
        }

        public static void GetJSONFile()
        {
            using (WebClient webClient = new WebClient())
            using (StreamWriter sw = new StreamWriter(@"C:\Elsewhere\fema.json", false))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                var json = webClient.DownloadString("https://www.fema.gov/api/open/v1/DisasterDeclarationsSummaries?$format=json");

                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, json);

            }

        }


    }
}
