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
         public HttpResponseMessage GetDetailResponse(string aadhar)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44341/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetAsync("api/PensionerDetail/" + aadhar).Result;
            }
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
             response = null;
            return response;
        }

        public string GetAdhaarNumber(string aadhar)
        {
            HttpResponseMessage response = GetDetailResponse(aadhar);
            string name = response.Content.ReadAsStringAsync().Result;
            dynamic details = JObject.Parse(name);
            return details.name;
        }

        public int GetAllowances(string adhaar)
        {
            HttpResponseMessage response = GetDetailResponse(adhaar);
            string name = response.Content.ReadAsStringAsync().Result;
            dynamic details = JObject.Parse(name);
            return details.allowances;
        }


        public int GetSalaryEarned(string adhaar)
        {
            HttpResponseMessage response = GetDetailResponse(adhaar);
            string name = response.Content.ReadAsStringAsync().Result;
            dynamic details = JObject.Parse(name);
            return details.salaryEarned;
        }

        public int GetPensionType(string adhaar)
        {
            HttpResponseMessage response = GetDetailResponse(adhaar);
            string name = response.Content.ReadAsStringAsync().Result;
            dynamic details = JObject.Parse(name);
            return details.pensionType;
        }
    }
}
