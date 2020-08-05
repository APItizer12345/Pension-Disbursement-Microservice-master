using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


//change get to post

namespace PensionDisbursement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PensionDisbursementController : ControllerBase
    {
        



        [HttpPost]
        public int GetDisbursePension(ProcessPensionInput pension)
        {


            

            PensionerDetail pensionerDetail = new PensionerDetail();
            GetPensionDetails getPensionerDetail = new GetPensionDetails();

            pensionerDetail = getPensionerDetail.GetDetailResponse(pension.aadharNumber);
            




            int status = 0;
            int bankServiceCharge;
            if (pension.bankType == 1)
                bankServiceCharge = 500;
            else if (pension.bankType == 2)
                bankServiceCharge = 550;
            else
                bankServiceCharge = 0;
            double pensionCalculated;
            try
            {
                int pType = pensionerDetail.pensionType;
            }
            catch (NullReferenceException e)
            {
                return 21;
            }
            if (pensionerDetail.pensionType == 1)
            {
                pensionCalculated = (pensionerDetail.salaryEarned * 0.8) + pensionerDetail.allowances + bankServiceCharge;
            }
            else
            {
                pensionCalculated = (pensionerDetail.salaryEarned * 0.5) + pensionerDetail.allowances + bankServiceCharge;
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
