using DDC.Client.MVVM.Model.DTOs;
using DDC.Client.MVVM.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDC.Client.MVVM.Model
{
    class AnnualDebtCalculation : IBankingCalculation 
    {
        public CalculationResult Calculate(decimal debtAmount, decimal interestRate, int months)
        {
            decimal monthlyInterestRate = interestRate / 100 / 12;
            decimal monthlyPayment = debtAmount * (monthlyInterestRate + (monthlyInterestRate / ((decimal)Math.Pow((double)(1 + monthlyInterestRate), months) - 1)));
            decimal totalInterest = monthlyPayment * months - debtAmount;
            decimal totalSum = debtAmount + totalInterest;
           
            
            var paymentHistory = GetPaymentHistory(debtAmount, months, monthlyInterestRate, monthlyPayment);

            return new CalculationResult
            {
                MonthlyPayment = monthlyPayment,
                TotalInterest = totalInterest,
                TotalSum = totalSum,
                PaymentHistory = paymentHistory
                
            };
        }

        private static List<PaymentInfo> GetPaymentHistory(decimal debtAmount, int months, decimal monthlyInterestRate, decimal monthlyPayment)
        {
            var currentBody = debtAmount;
            var paymentHistory = new List<PaymentInfo>();
            for (int i = 0; i < months; i++)
            {
                var percentagePaymentPart = currentBody * monthlyInterestRate;
                var anunualPaymentPart = monthlyPayment - percentagePaymentPart;
                paymentHistory.Add(new DebtPaymentInfo
                {
                    Body = currentBody,
                    MoneyChanges = monthlyPayment,
                    CurrentTotal = currentBody - monthlyPayment + percentagePaymentPart,
                    PercentagePaymentPart = percentagePaymentPart,
                    AnnualPaymentPart = anunualPaymentPart,
                    MonthNumber = i + 1

                });

                currentBody -= anunualPaymentPart;

            }
            return paymentHistory;
        }
    }
}
