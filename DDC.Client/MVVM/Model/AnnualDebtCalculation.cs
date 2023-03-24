using DDC.Client.MVVM.Model.DTOs;
using DDC.Client.MVVM.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDC.Client.MVVM.Model
{
    class AnnualDebtCalculation : IDebtCalculation 
    {
        public DebtCalculationResult Calculate(decimal debtAmount, decimal interestRate, int months)
        {
            decimal monthlyInterestRate = interestRate / 100 / 12;
            decimal monthlyPayment = debtAmount * (monthlyInterestRate + (monthlyInterestRate / ((decimal)Math.Pow((double)(1 + monthlyInterestRate), months) - 1)));
            decimal totalInterest = monthlyPayment * months - debtAmount;
            decimal totalSum = debtAmount + totalInterest;
           
            
            var paymentHistory = GetPaymentHistory(debtAmount, months, monthlyInterestRate, monthlyPayment);

            return new DebtCalculationResult
            {
                MonthlyPayment = monthlyPayment,
                TotalInterest = totalInterest,
                TotalSum = totalSum,
                PaymentHistory = paymentHistory
                
            };
        }

        private static List<DebtPaymentInfo> GetPaymentHistory(decimal debtAmount, int months, decimal monthlyInterestRate, decimal monthlyPayment)
        {
            var currentBody = debtAmount;
            var paymentHistory = new List<DebtPaymentInfo>();
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
