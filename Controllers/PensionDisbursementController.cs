using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PensionDisbursement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PensionDisbursementController : ControllerBase
    {
        //ProcessPensionInput pension = new ProcessPensionInput
        //{
        //    adhaarNumber = "111122223333",
        //    pensionAmount = 35550,
        //    bankServiceCharge = 550
        //};



        [HttpGet]
        public int GetDisbursePension()
        {
            ProcessPensionInput pension = new ProcessPensionInput();
            GetProcessPensionValue getPensionDetail = new GetProcessPensionValue();


            pension.adhaarNumber = getPensionDetail.GetAdhaarNumber();
            pension.pensionAmount = getPensionDetail.GetPensionAmount();
            pension.bankServiceCharge = getPensionDetail.GetServiceCharge();





            int status = 0;

            PensionerDetail pensionerDetail = new PensionerDetail();
            GetPensionDetails getPensionerDetail = new GetPensionDetails();

            pensionerDetail.adhaarNumber = getPensionerDetail.GetAdhaarNumber(pension.adhaarNumber);
            pensionerDetail.allowances = getPensionerDetail.GetAllowances(pension.adhaarNumber);
            pensionerDetail.salaryEarned = getPensionerDetail.GetSalaryEarned(pension.adhaarNumber);
            pensionerDetail.pensionType = getPensionerDetail.GetPensionType(pension.adhaarNumber);

           


            double pensionCalculated;
            if (pensionerDetail.pensionType == 1)
            {
                pensionCalculated = (pensionerDetail.salaryEarned * 0.8) + pensionerDetail.allowances + pension.bankServiceCharge;
            }
            else // if ((pensionerDetail.PensionType).Equals(familyType))
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
