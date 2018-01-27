using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using FemaAPIWrapper.Infrastructure;
using System.IO;
using System.Net;

namespace FemaAPIWrapper
{
    class Program
    {
        static HttpClient httpClient = new HttpClient();
        
        static void Main(string[] args)
        {

            var dds = GetDisasterDeclarationSummaries();

            var ddsJson = JsonConvert.DeserializeObject<FemaInfo.FemaInfo>(dds.Result);

            FemaRepository femaRepository = new FemaRepository();
            femaRepository.InsertAll(ddsJson.DisasterDeclarationsSummaries);
           
        }

        public static async Task<string> GetDisasterDeclarationSummaries()
        {
            
            HttpResponseMessage resp = httpClient.GetAsync("https://www.fema.gov/api/open/v1/DisasterDeclarationsSummaries?$filter=declarationDate%20gt%20%272017-09-08T12:35:00.000z%27").Result;
            resp.EnsureSuccessStatusCode();

            var jsonString = await resp.Content.ReadAsStringAsync();

            return jsonString;
        }

        public static async Task<string> GetHazardMitigationGrants()
        {
            HttpResponseMessage resp = httpClient.GetAsync("https://www.fema.gov/api/open/v1/HazardMitigationGrants").Result;
            resp.EnsureSuccessStatusCode();

            var jsonString = await resp.Content.ReadAsStringAsync();

            return jsonString;
        }

        public static void GetJSONFile(string apiEndpoint)
        {
            apiEndpoint = apiEndpoint.Trim();
            string url = $"https://www.fema.gov/api/open/v1/" + apiEndpoint + "?$format=json";
            using (WebClient webClient = new WebClient())
            using (StreamWriter sw = new StreamWriter($@"C:\fema\{apiEndpoint}.json", false))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                var json = webClient.DownloadString(url); //Example: https://www.fema.gov/api/open/v1/{apiEndpoint}?$format=json

                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, json);

            }
            Console.WriteLine($"Download of {apiEndpoint} complete.");

        }


    }
}
