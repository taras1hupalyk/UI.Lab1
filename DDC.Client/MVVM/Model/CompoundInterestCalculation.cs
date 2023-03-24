using DDC.Client.MVVM.Model.DTOs;
using DDC.Client.MVVM.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDC.Client.MVVM.Model
{
    class CompoundInterestCalculation : IBankingCalculation
    {
        public CalculationResult Calculate(decimal moneyAmount, decimal interestRate, int months)
        {
            var currentSum = moneyAmount;
            var paymentHistory = new List<PaymentInfo>();
            for (int i = 0; i < months; i++)
            {
                var currentBody = currentSum;
                currentSum *= (1 + interestRate / 100 / 12);


                paymentHistory.Add(new PaymentInfo
                {
                    MonthNumber = i + 1,
                    Body = currentBody,
                    MoneyChanges = currentSum - currentBody,
                    CurrentTotal = currentSum
                });
            }

            return new CalculationResult
            {
                MonthlyPayment = (currentSum -moneyAmount) / months,
                TotalInterest = currentSum - moneyAmount,
                PaymentHistory = paymentHistory,
                TotalSum = currentSum
            };
        }
    }


}
