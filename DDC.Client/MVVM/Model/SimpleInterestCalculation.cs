using DDC.Client.MVVM.Model.Interfaces;
using System;

namespace DDC.Client.MVVM.Model
{
    internal class SimpleInterestCalculation : IBankingCalculation
    {
        public CalculationResult Calculate(decimal depositAmount, decimal interestRate, int months)
        {
            var depositStartingTime = DateTime.Now;
            var depositEndingTime = DateTime.Now.AddMonths(months);
            var yearDaysAmount = DateTime.IsLeapYear(depositStartingTime.Year) ? 366 : 365;

            var depositTerm = depositEndingTime - depositStartingTime;

            var totalInterest = depositAmount * interestRate * depositTerm.Days / yearDaysAmount / 100;


            var result = new CalculationResult
            {
                MonthlyPayment = totalInterest / months,
                TotalInterest = totalInterest,
                TotalSum = depositAmount + totalInterest
            };
            return result;
        }
    }
}