using DDC.Client.MVVM.Model.DTOs;
using DDC.Client.MVVM.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace DDC.Client.MVVM.Model
{
    internal class SimpleInterestCalculation : IDepositCalculation
    {
        public DepositCalculationResult Calculate(decimal depositAmount, decimal interestRate, int months)
        {
            var depositStartingTime = DateTime.Now;
            var depositEndingTime = DateTime.Now.AddMonths(months);
            var yearDaysAmount = DateTime.IsLeapYear(depositStartingTime.Year) ? 366 : 365;

            var depositTerm = depositEndingTime - depositStartingTime;

            var totalInterest = depositAmount * interestRate * depositTerm.Days / yearDaysAmount / 100;

            var paymentHistory = new List<PaymentInfo>();
            decimal monthlyPayment = totalInterest / months;
            var currentBody = depositAmount;

            for (int i = 0; i < months; i++)
            {
                paymentHistory.Add(new PaymentInfo
                {
                    MonthNumber = i + 1,
                    Body = currentBody,
                    MoneyChanges = monthlyPayment,
                    CurrentTotal = currentBody + monthlyPayment
                });

                currentBody += monthlyPayment;
            }


            var result = new DepositCalculationResult
            {
                MonthlyPayment = monthlyPayment,
                TotalInterest = totalInterest,
                TotalSum = depositAmount + totalInterest,
                PaymentHistory = paymentHistory
            };
            return result;
        }
    }
}