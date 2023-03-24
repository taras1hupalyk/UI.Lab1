using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDC.Client.MVVM.Model.DTOs
{
    public class DepositCalculationResult : CalculationResult
    {
        public List<PaymentInfo> PaymentHistory { get; set; }
    }
}
