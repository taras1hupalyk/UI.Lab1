using DDC.Client.MVVM.Model.DTOs;
using System.Collections.Generic;

namespace DDC.Client.MVVM.Model.Interfaces
{
    public class DebtCalculationResult : CalculationResult
    {
        public   List<DebtPaymentInfo> PaymentHistory { get; set; }

    }
}