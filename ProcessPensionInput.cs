using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionDisbursement
{
    public class ProcessPensionInput
    {
        public string adhaarNumber { get; set; }
        public double pensionAmount { get; set; }
        public int bankServiceCharge { get; set; }
    }
}
