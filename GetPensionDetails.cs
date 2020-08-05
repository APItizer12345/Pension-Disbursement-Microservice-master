using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PensionDisbursement
{
    public class GetPensionDetails
    {
         public PensionerDetail GetDetailResponse(string aadhar)
        {
           
            HttpResponseMessage response = new HttpResponseMessage();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44341/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    response = client.GetAsync("api/PensionerDetail/" + aadhar).Result;
                }
                catch (Exception e) { response = null; }
            }

            string detailsResponse = response.Content.ReadAsStringAsync().Result;
            PensionerDetail pen = JsonConvert.DeserializeObject<PensionerDetail>(detailsResponse);
            
            return pen;
        }

       
    }
}
