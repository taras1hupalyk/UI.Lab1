using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDC.Client.MVVM.Model.DTOs
{
    internal class DebtPaymentInfo : PaymentInfo
    {
        public decimal PercentagePaymentPart { get; set; }

        public decimal AnnualPaymentPart { get; set; }

        
    }
}
