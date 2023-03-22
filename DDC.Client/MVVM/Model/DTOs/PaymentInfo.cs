using System;

namespace DDC.Client.MVVM.Model.DTOs
{
    public class PaymentInfo
    {
        public int MonthNumber { get; set; }

        public decimal Body { get; set; }

        public decimal MoneyChanges { get; set; }

        public decimal CurrentTotal { get; set; }

        public string   CalculationMethod { get; set; }

        public override string ToString()
        {
            var monthNumber = MonthNumber.ToString();
            var body = Body.ToString("F2");
            var moneyChanges = MoneyChanges.ToString("F2");
            var currentTotal = CurrentTotal.ToString("F2");

            return String.Format("| {0,-10} | {1,-10} | {2,-10} |  {3, -10}"
                                , monthNumber, body, moneyChanges, currentTotal);
        }

    }
}