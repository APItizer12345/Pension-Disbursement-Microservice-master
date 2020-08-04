using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PensionDisbursement
{
    public class GetProcessPensionValue
    {
        public HttpResponseMessage GetProcessPensionResponse()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44394/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    response = client.GetAsync("api/ProcessPension").Result;
                }
                catch(Exception e) { response = null; }
            }
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
                response = null;

            return response;
        }

        //public string GetAdhaarNumber()
        //{
        //    HttpResponseMessage response = GetProcessPensionResponse();
        //    string name = response.Content.ReadAsStringAsync().Result;
        //    dynamic details = JObject.Parse(name);
        //    return details.aadhar;
        //}


        //public double GetPensionAmount()
        //{
        //    HttpResponseMessage response = GetProcessPensionResponse();
        //    string amount = response.Content.ReadAsStringAsync().Result;
        //    dynamic details = JObject.Parse(amount);
        //    return details.pensionAmount;
        //}

        //public int GetServiceCharge()
        //{
        //    HttpResponseMessage response = GetProcessPensionResponse();
        //    string name = response.Content.ReadAsStringAsync().Result;
        //    dynamic details = JObject.Parse(name);
        //    return details.serviceCharge;
        //}

        
    }
}
