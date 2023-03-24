using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDC.Client.MVVM.Model.DTOs
{
    public class DebtPaymentInfo : PaymentInfo
    {
        public decimal PercentagePaymentPart { get; set; }

        public decimal AnnualPaymentPart { get; set; }


        public override string ToString()
        {
            var monthNumber = MonthNumber.ToString();
            var body = Body.ToString("F2");
            var moneyChanges = MoneyChanges.ToString("F2");
            var currentTotal = CurrentTotal.ToString("F2");
            var percentagePaymentPart = PercentagePaymentPart.ToString("F2");
            var annualPaymentPart = AnnualPaymentPart.ToString("F2");

            return String.Format("| {0,-10} | {1,-10} | {2,-10} |  {3, -10}  | {4,-10} | {5,-10} | "
                                , monthNumber, body, moneyChanges,  percentagePaymentPart, annualPaymentPart, currentTotal);
        }
    }
}
