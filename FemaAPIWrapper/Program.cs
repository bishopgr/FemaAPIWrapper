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

            var dds = GetDisasterDeclarationSummaries();
            var hmg = GetHazardMitigationGrants();

            var ddsJson = JsonConvert.DeserializeObject<FemaInfo.FemaInfo>(dds.Result);
            var hmgJson = JsonConvert.DeserializeObject<FemaInfo.FemaInfo>(hmg.Result);

            ddsJson.DisasterDeclarationsSummaries.OrderByDescending(j => j.DisasterNumber);
            hmgJson.HazardMitigationGrants.OrderByDescending(h => h.Region);

            foreach (var j in ddsJson.DisasterDeclarationsSummaries.Take(100))
            {
                if (!j.PlaceCode.HasValue)
                {
                    j.PlaceCode = -1;
                }
                Console.WriteLine($"{j.DisasterNumber}, {j.Title}, {j.State}, {j.PlaceCode}");
            }

            foreach(var h in hmgJson.HazardMitigationGrants.Take(100))
            {
                Console.WriteLine($"{h.State}, {h.Status}, {h.IncidentType}, {h.ProjectType}");
            }



            //GetJSONFile();
        }

        public static async Task<string> GetDisasterDeclarationSummaries()
        {
            HttpResponseMessage resp = httpClient.GetAsync("https://www.fema.gov/api/open/v1/DisasterDeclarationsSummaries").Result;
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

        public static void GetJSONFile()
        {
            using (WebClient webClient = new WebClient())
            using (StreamWriter sw = new StreamWriter(@"C:\fema\fema.json", false))
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
