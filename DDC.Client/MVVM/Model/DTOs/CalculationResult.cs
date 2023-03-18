using DDC.Client.MVVM.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDC.Client.MVVM.Model.DTOs
{
    class CalculationResult
    {
        public List<PaymentInfo> PaymentHistory { get; set; }


        public decimal MonthlyPayment { get; set; }

        public decimal TotalInterest { get; set; }

        public decimal TotalSum { get; set; }


    }
}
