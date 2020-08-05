using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PensionDisbursement
{
    //public class GetProcessPensionValue
    //{
    //    public HttpResponseMessage GetProcessPensionResponse()
    //    {
    //        string token = GetToken("https://localhost:44394/");
    //        HttpResponseMessage response = new HttpResponseMessage();
    //        using (var client = new HttpClient())
    //        {
    //            client.BaseAddress = new Uri("https://localhost:44394/");
    //            client.DefaultRequestHeaders.Clear();
    //            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    //            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    //            try
    //            {
    //                response = client.GetAsync("api/ProcessPension").Result;
    //            }
    //            catch (Exception e) { response = null; }
    //        }
            

    //        return response;
    //    }


    //    static string GetToken(string url)
    //    {
    //        Authenticate user = new Authenticate { name = "Deepanshu", password = "Deepanshu12" };
    //        var json = JsonConvert.SerializeObject(user);
    //        var data = new StringContent(json, Encoding.UTF8, "application/json");

    //        using (var client = new HttpClient())
    //        {
    //            var response = client.PostAsync(url, data).Result;
    //            string name = response.Content.ReadAsStringAsync().Result;
    //            string token = JsonConvert.DeserializeObject<string>(name);
    //            return token;
    //        }
    //    }

    //    //public string GetAdhaarNumber()
    //    //{
    //    //    HttpResponseMessage response = GetProcessPensionResponse();
    //    //    string name = response.Content.ReadAsStringAsync().Result;
    //    //    dynamic details = JObject.Parse(name);
    //    //    return details.aadhar;
    //    //}


    //    //public double GetPensionAmount()
    //    //{
    //    //    HttpResponseMessage response = GetProcessPensionResponse();
    //    //    string amount = response.Content.ReadAsStringAsync().Result;
    //    //    dynamic details = JObject.Parse(amount);
    //    //    return details.pensionAmount;
    //    //}

    //    //public int GetServiceCharge()
    //    //{
    //    //    HttpResponseMessage response = GetProcessPensionResponse();
    //    //    string name = response.Content.ReadAsStringAsync().Result;
    //    //    dynamic details = JObject.Parse(name);
    //    //    return details.serviceCharge;
    //    //}


    //}

    //public class Authenticate
    //    {
    //    public string name { get; set; }
    //    public string password { get; set; }
    //}
}
