using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace PensionDisbursement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PensionDisbursementController : ControllerBase
    {
        



        [HttpGet]
        public int GetDisbursePension()
        {



            ProcessPensionInput pension = new ProcessPensionInput();
            GetProcessPensionValue getProcessPensionDetail = new GetProcessPensionValue();


            HttpResponseMessage _processPensionResponse = getProcessPensionDetail.GetProcessPensionResponse();
            if (_processPensionResponse == null)
            {
                return 21;
            }
            string processPensionResponse = _processPensionResponse.Content.ReadAsStringAsync().Result;
            dynamic processPensiondetails = JObject.Parse(processPensionResponse);
            pension.adhaarNumber = processPensiondetails.aadhar;
            pension.pensionAmount = processPensiondetails.pensionAmount;
            pension.bankServiceCharge = processPensiondetails.serviceCharge;

            

            PensionerDetail pensionerDetail = new PensionerDetail();
            GetPensionDetails getPensionerDetail = new GetPensionDetails();


            HttpResponseMessage _detailsResponse = getPensionerDetail.GetDetailResponse(pension.adhaarNumber);
            if (_detailsResponse == null)
            {
                return 21;
            }
            string detailsResponse = _detailsResponse.Content.ReadAsStringAsync().Result;
            dynamic details = JObject.Parse(detailsResponse);


            pensionerDetail.allowances = details.allowances;
            pensionerDetail.salaryEarned = details.salaryEarned;
            pensionerDetail.pensionType = details.pensionType;




            int status = 0;

            double pensionCalculated;
            if (pensionerDetail.pensionType == 1)//change equating method
            {
                pensionCalculated = (pensionerDetail.salaryEarned * 0.8) + pensionerDetail.allowances + pension.bankServiceCharge;
            }
            else
            {
                pensionCalculated = (pensionerDetail.salaryEarned * 0.5) + pensionerDetail.allowances + pension.bankServiceCharge;
            }

            if (Convert.ToDouble(pension.pensionAmount) == pensionCalculated)
            {
                status = 10;
            }
            else
            {
                status = 21;
            }
            return status;
            
        }

    }
}
