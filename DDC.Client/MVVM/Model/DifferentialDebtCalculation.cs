using DDC.Client.MVVM.Model.DTOs;
using DDC.Client.MVVM.Model.Interfaces;
using System.Collections.Generic;

namespace DDC.Client.MVVM.Model
{
    class DifferentialDebtCalculation : IBankingCalculation
    {
        public CalculationResult Calculate(decimal debtAmount, decimal interestRate, int months)
        {
            decimal monthlyPayment = debtAmount / months;
            decimal totalInterest = 0;
            decimal totalSum = 0;

            var paymentHistory = new List<PaymentInfo>();
            var currentDebtBody = debtAmount;
            for (int i = 0; i < months; i++)
            {
                decimal interest = (debtAmount - (monthlyPayment * i)) * (interestRate / 100) / 12;
                totalInterest += interest;
                totalSum += monthlyPayment + interest;

                paymentHistory.Add(new DebtPaymentInfo
                {
                    Body = currentDebtBody,
                    MoneyChanges = monthlyPayment + interest,                    
                    CurrentTotal = currentDebtBody - monthlyPayment,
                    PercentagePaymentPart = interest,
                    AnnualPaymentPart = monthlyPayment,
                    MonthNumber = i + 1
                });
                currentDebtBody -= monthlyPayment;
            }

            return new CalculationResult
            {
                MonthlyPayment = monthlyPayment,
                TotalInterest = totalInterest,
                TotalSum = totalSum,
                PaymentHistory = paymentHistory

            };
        }
    }

}

